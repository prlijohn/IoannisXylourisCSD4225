using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace formsWeb.Models
{
    public class QuestionTranslation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Questionnaire")]
        public int QuestionId { get; set; }
        public Questionnaire Questionnaire { get; set; }

        [ForeignKey("QuestionType")]
        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }
        public string lang_code { get; set; }
        public string question_text { get; set; }

    }
}
