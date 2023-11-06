using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace formsWeb.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Questionnaire")]
        public int QuestionId { get; set; }
        public Questionnaire Questionnaire { get; set; }

        [ForeignKey("QuestionType")]
        public int questionType { get; set; }
        public QuestionType QuestionType { get; set; } 



    }
}
