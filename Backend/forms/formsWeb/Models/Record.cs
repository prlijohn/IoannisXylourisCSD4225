using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace formsWeb.Models
{
    public class Record
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Forms")]
        public int FormId;
        public Form Forms { get; set; }
        [ForeignKey("Patients")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Questionnaire")]
        public int QuestId { get; set; }
        public Questionnaire Questionnaire { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        [ForeignKey("QuestionType")]
        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }

        [ForeignKey("Answer_Map")]
        public int AnswerId { get; set; }
        public Answer_map Answer { get; set; }
        public int? score { get; set; }
        
        public string? Text { get; set; }
        public byte[]? Image { get; set; }
        public bool? Checked { get; set; }
        
    }
}
