using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace formsWeb.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Patients")]

        public int PatientId;
        public Patient Patients { get; set; }

        [ForeignKey("Questionnaire")]
        public int QuestId { get; set; }
        public Questionnaire Questionnaire { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public List<string>? expression { get; set; }

        public List<double>? score { get; set; }
    }
}
