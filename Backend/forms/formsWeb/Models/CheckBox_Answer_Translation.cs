using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace formsWeb.Models
{
    public class CheckBox_Answer_Translation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Questionnaire")]
        public int QuestionnaireId { get; set; }

        public Questionnaire Questionnaire { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        public Question Question{ get; set; }


        public string lang_code { get; set; }

        public string text { get; set; }

        public int score { get; set; }

    }
}