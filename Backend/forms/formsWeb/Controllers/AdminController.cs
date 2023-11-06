using formsWeb.Data;
using formsWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace formsWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IHttpContextAccessor _cntx;
        public AdminController(ApplicationDbContext db, IHttpContextAccessor cntx)
        {
            _db = db;
            _cntx = cntx;
        }
        [Authorize]
        public async Task  <IActionResult> Index()
        {
            await Calculate();
            var forms = _db.Forms.ToList();

            var records = _db.Records            
            .Select(c => new Record
            {
                Id = c.Id,
                FormId = c.FormId,
                PatientId = c.PatientId,
                QuestId = c.QuestId,
                QuestionId = c.QuestionId,
                score = c.score
            }).ToList();

            var patients = _db.Patients.ToList().OrderBy(c => c.Id);

            var all_quests = _db.Questionnaire.ToList().OrderBy(c => c.Id); ;

            var send = new
            {
                forms,
                records,
                patients,
                all_quests
            };
            
            return View(send);            
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id.HasValue)
            {
                
                //All record IDs
                var filteredData = await _db.Records
                    .Where(c => c.FormId == id)
                    .ToListAsync();
                //Questionnare Name through ID

                /*
                 * All the answers should have the same Questionnaire Id.
                 * Therefore I execute the query base on the first retrieved answered
                 * ID
                 */
                //Retrieve Patient's Data
                var patient = await _db.Patients
                    .Where(c => c.Id == filteredData[0].PatientId)
                    .FirstOrDefaultAsync();
                var Questionnaire = await _db.Questionnaire
                    .Where(c => c.Id == filteredData[0].QuestId)
                    .FirstOrDefaultAsync();
                //All Questionnare Questions

                /*
                 * Retrieve based on language provided
                 * by default "en"
                 */
                List<QuestionTranslation> model_quest = new List<QuestionTranslation>();
                foreach (Record rec in filteredData)
                {
                    var temp_quest = await _db.QuestionTranslations
                    .Where(c => c.Id == rec.QuestionId)
                    .FirstOrDefaultAsync();
                    model_quest.Add(temp_quest);
                }

                

                //All Questionnaire Answers
                List <string> text = new List<string>();
                List <bool> check = new List<bool>();
                List <Radio_Answer_Translation> model = new List <Radio_Answer_Translation>();
                List <CheckBox_Answer_Translation> model_check = new List< CheckBox_Answer_Translation>();

                foreach (Record rec in filteredData)
                {
                    
                    if (rec.QuestionTypeId == 1)
                    {
                        var temp_answers = await _db.Radio_Answer_Translations
                            .Where(c => c.Id == rec.AnswerId)
                            .FirstOrDefaultAsync();

                        model.Add(temp_answers);
                    }

                    if (rec.QuestionTypeId == 2)
                    {
                        text.Add(rec.Text);
                    }

                    if (rec.QuestionTypeId == 3)
                    {
                        //retrieve image here
                    }

                    if (rec.QuestionTypeId == 4)
                    {
                        var temp_answers = await _db.CheckBox_Answer_Translations
                            .Where(c => c.QuestionId == rec.QuestionId)
                            .FirstOrDefaultAsync();

                        model_check.Add(temp_answers);
                        check.Add((bool)rec.Checked);
                    }
                   
                }

                var answers = new
                {
                    model,
                    model_check,
                    text,
                    check
                };

                var mode = new 
                {
                    patient,
                    Questionnaire,
                    answers,
                    model_quest
                    
                };

                
                return View(mode);

                
            }
            else
            {
                return View();
            }
            
        }
        
        public async Task  Calculate()
        {
            //retrieve all the expressions from each questionnaire
            var expressions = _db.Questionnaire.Select(c => new Questionnaire
            {
                Id = c.Id,
                expression = c.expression
            })
            .ToList()
            .OrderBy( e => e.Id);
            var forms = _db.Forms.ToList().OrderBy(e => e.Id);
            var records  = _db.Records.ToList().OrderBy(e => e.FormId);
            
            //sum of 5 first / 5 & sum of 5 last / 5            
            //iterate through all forms filled
            foreach ( Form form in forms)
            {
                if (form.QuestId == 1)
                {
                    
                    double custom1 = 0;
                double custom2 = 0;
                double average = 0;
                var question_n = 0; 
                double sum = 0;
                if (form.expression != null) continue;
                foreach ( Record record in records.Where(c => c.FormId == form.Id)){
                    question_n++;
                    sum = sum + (double) record.score;
                    average = sum;
                    if(question_n < 6)
                    {
                        custom1 = custom1 + (double)record.score;
                    }
                    else
                    {
                        if(question_n == 6)
                        {
                            custom1 = (double)custom1/5;
                        }
                        custom2 = custom2 + (double)record.score;

                    }
                }
                average = (double)average/question_n;
                custom2 = (double)custom2/5;
                custom2 = (double)custom2+custom1;                    

                form.expression = new List<string>();
                form.expression.Add("Sum");
                form.expression.Add("Average");
                form.expression.Add("Custom");

                form.score = new List<double>();
                form.score.Add(sum);
                form.score.Add(average);
                form.score.Add(custom2);

                _db.Entry(form).State = EntityState.Modified;

            }else if (form.QuestId == 2)
                {
                    double sum = 0;
                    if (form.expression != null) continue;
                    foreach (Record record in records.Where(c => c.FormId == form.Id)) {
                        sum = sum + (double)record.score;
                    }
                    form.expression = new List<string>();
                    form.expression.Add("Sum");
                    form.score = new List<double>();
                    form.score.Add(sum);
                }

           await _db.SaveChangesAsync();

            }         
        }
    }
}
