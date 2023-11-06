
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace formsWeb.Models.ViewModel
{

    public class QuestionViewModel
    {
        //Question Id
        public int Id { get; set; }
        [ForeignKey("Questionnaire")]
        public int QuestId { get; set; }

        public Questionnaire Questionnaire { get; set; }

        //Question Text from question translation
        public string? Question { get; set; }        

        //All given radio selections from radioanswer 
        public IList<Radio_Answer_Translation>? Options { get; set; }

        public IList<CheckBox_Answer_Translation>? OptionsCheck { get; set; }

        public IFormFile ImageBytes { get; set; }

        public string? Text { get; set; }
        public int QuestionType { get; set; }
        public bool Checked { get; set; }

        //Then one that the user selected
        public int Selected { get; set; }
        //The score from the user's selection
        public double Score { get; set; }

        public int total { get; set; } = 0;

        public int next { get; set; } 
        
    }
}
