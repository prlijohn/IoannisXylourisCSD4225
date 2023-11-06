using formsWeb.Data;
using formsWeb.Models;
using formsWeb.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;



namespace formsWeb.Controllers
{
    public class QuestionnaireController : Controller
    {

        
        

        //initialization of the db
        private readonly ApplicationDbContext _db;

        private readonly IHttpContextAccessor _cntx;
        public QuestionnaireController(ApplicationDbContext db, IHttpContextAccessor cntx)        {

            _db = db;
            _cntx = cntx;
        }

        //this is the dropdown to select the questionnaire
        //
        [Authorize]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            var model = new QuestionnaireViewModel();
            var question_model = new QuestionViewModel();
            var combinedViewModel = new Combined()
            {
                Questionnaire = model,
                Question = question_model
            };
            var obj = _db.Questionnaire
                .OrderBy(c => c.Id)
                .ToList();            
            
            model.QuestSelectList = new List<SelectListItem>();
            foreach (var element in obj) {
                model.QuestSelectList.Add(new SelectListItem { Text = element.Name , Value = element.Id.ToString()});
            }
            
            string user = JsonConvert.SerializeObject(combinedViewModel);
            _cntx.HttpContext?.Session.SetString("User", user);
            

            return View(combinedViewModel);
            
        }


        
        
        /*        
        They should be seperated from questionnaire
        This one should handle every single question
        and lastly redirect to a Summary page #TODO
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Question(Combined model )
        {
            Combined mode = new Combined();
            string user = _cntx.HttpContext.Session.GetString("User");
            mode = JsonConvert.DeserializeObject<Combined>(user);

            
            //if questionnaire is null it means that we have an answer to a question
            //if question is null it means that we have a questionnaire selection         

            if (model.Questionnaire != null)
            {
                var first = _db.Questions
                    .Where(c => c.QuestionId == model.Questionnaire.QuestSelected)
                    .Select(c => new Question
                    {
                        Id = c.Id,
                        QuestionId = c.QuestionId,
                        questionType = c.questionType

                    }).ToList();
                int lowest = first.Min(c => c.Id);

                mode.Question.QuestId = model.Questionnaire.QuestSelected;
                mode.Question.Id = lowest;
                mode.Question.next = lowest;
                mode.Questionnaire.QuestSelected = model.Questionnaire.QuestSelected;
                
                var newForm = new Form
                {
                    PatientId = int.Parse(User.FindFirst("PatientId").Value),
                    Start = DateTime.Now.ToUniversalTime(),
                    QuestId = mode.Questionnaire.QuestSelected
                };
                mode.Forms = newForm;
                _db.Forms.Add(newForm);
                _db.SaveChanges();
            }
            

            //only happens if there is an answer            
              if( model.Question != null)
              {
                mode.Question.Selected = model.Question.Selected;
                mode.Question.total = mode.Question.total + model.Question.Selected;
                var answers = GetNextQuestion(mode);
                mode.Question.next = answers.nextQuestion;
                mode.Question.Text = model.Question.Text;
                mode.Question.ImageBytes = null;
                mode.Question.Checked = model.Question.Checked;
                byte[] imageData = null;
                //Here photo should be handled and saved to db
                /*
                if (model.Question.ImageBytes != null && model.Question.ImageBytes.Length != 0)
                {
                  
                }*/
                var newRow = new Record
              {
                  
                    //after the authentication this will be changed                    
                    PatientId = int.Parse(User.FindFirst("PatientId").Value),
                    FormId = mode.Forms.Id,
                    QuestId = mode.Question.QuestId,
                    QuestionId = mode.Question.Id,    
                    AnswerId = answers.Id,
                    QuestionTypeId = mode.Question.QuestionType,
                    score = answers.score,
                    Checked = mode.Question.Checked,
                    Image = null,
                    Text = mode.Question.Text
                };
                 _db.Records.Add(newRow);
                 _db.SaveChanges();
              }

              

            mode.Question.Id = mode.Question.next;   

            //END OF THE QUESTIONNAIRE
            if(mode.Question.Id == 0)
            {
                //FIX SAVE TO DATABASE
                //PROPABLY NEED TO ADD IN QVM PATIENT TO KEEP TRACK OF ITS DATA TILL THE SUMMARY 
                mode.Forms.End = DateTime.Now.ToUniversalTime();

                var entity = _db.Forms.FirstOrDefault(e => e.Id == mode.Forms.Id);

                if (entity != null)
                {
                    entity.End = DateTime.Now.ToUniversalTime();
                    _db.SaveChanges();
                }                

                return View("Summary", mode);
                
            }  

              

                var questions = _db.Questions
                    .Where(c => c.Id == mode.Question.Id)
                    .Select(c => new Question
                    {
                        Id = c.Id,
                        QuestionId = c.QuestionId,
                        questionType = c.questionType

                    }).FirstOrDefault();

                if(questions != null)
                {
                //model.Question.Id = questions.Id;
                //model.Question.QuestId = questions.QuestionId;
                //model.Question.QuestionType = questions.questionType;
                mode.Question.Id = questions.Id;
                mode.Question.QuestId = questions.QuestionId;
                mode.Question.QuestionType = questions.questionType;                

                }       

                var quest_transl = _db.QuestionTranslations
                        .Where(c => c.QuestionId == mode.Question.QuestId && c.lang_code== "en" && c.Id == mode.Question.Id )
                        .Select(c => new QuestionTranslation
                        {
                            Id = c.Id,                    
                            lang_code = c.lang_code,
                            question_text = c.question_text,
                    }).FirstOrDefault();
                mode.Question.Question = quest_transl.question_text;

                if(mode.Question.QuestionType == 1)
                {
                        var questionnaire = await Radio_Answer(mode.Question.QuestId , mode.Question.Id , "en");
                            
                           /* _db.Radio_Answer_Translations
                            .Where( c=> c.QuestionnaireId == mode.Question.QuestId && c.RadioId == quest_transl.Id  && c.lang_code == "en" )
                            .Select( c=> new Radio_Answer_Translation
                            {
                                RadioId = c.RadioId,
                                text = c.text,
                                score = c.score
                            })
                            .ToList();*/
                    mode.Question.Options = questionnaire; 
                }else if (mode.Question.QuestionType == 2)
                { 
                    
                    /*var questionnaire = await Text_Answer(mode.Question.QuestId, mode.Question.Id, "en");
                    mode.Question.Options = questionnaire;*/
                }
                else if (mode.Question.QuestionType == 3)
                {
                   /* var questionnaire = await Image_Answer(mode.Question.QuestId, mode.Question.Id, "en");
                    mode.Question.Options = questionnaire;*/
                }
                else if (mode.Question.QuestionType == 4)
                {
                    var questionnaire = await Checkbox_Answer(mode.Question.QuestId, mode.Question.Id, "en");
                    mode.Question.OptionsCheck = questionnaire;
                }

            
            var use = JsonConvert.SerializeObject(mode);
            _cntx.HttpContext.Session.SetString("User", use);
            return View(mode);
        }
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Answer(QuestionViewModel model)
        {
            var obj = model;
            return View(model);
            
        }
        */        
        public Answer_map GetNextQuestion(Combined mode)
        {
                           
            var questionnaire = _db.Answer_Maps
            .Where(c => c.QuestionnaireId == mode.Question.QuestId && c.QuestionId ==  mode.Question.Id && c.score == mode.Question.Selected)
            .Select(c => new Answer_map
            {
                nextQuestion = c.nextQuestion,
                Id = c.Id,
                score = c.score
                //answerId = c.AnswerId
            }).First();            
            return questionnaire;
        }
        
        public  async Task <List<Radio_Answer_Translation>> Radio_Answer( int QuestId , int Id , string lang_code)
        {

            var filteredData = await _db.Radio_Answer_Translations
                .Where(c => c.QuestionnaireId == QuestId && c.QuestionId == Id && c.lang_code == lang_code)
                .Select(c => new Radio_Answer_Translation
                {
                    Id = c.Id,
                    QuestionId = c.QuestionId,
                    text = c.text,
                    score = c.score
                })
                .ToListAsync();

            var orderedQuestionnaire = filteredData.OrderBy(c => c.Id).ToList();
            return orderedQuestionnaire;
            

        }
        public async Task<List<CheckBox_Answer_Translation>> Checkbox_Answer(int QuestId, int Id, string lang_code)
        {

            var filteredData = await _db.CheckBox_Answer_Translations
                .Where(c => c.QuestionnaireId == QuestId && c.QuestionId == Id && c.lang_code == lang_code)
                .Select(c => new CheckBox_Answer_Translation
                {
                    Id = c.Id,
                    QuestionId = c.QuestionId,
                    text = c.text,
                })
                .ToListAsync();

            var orderedQuestionnaire = filteredData.OrderBy(c => c.Id).ToList();
            return orderedQuestionnaire;


        }
    }
}
