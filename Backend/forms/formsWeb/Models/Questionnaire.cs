using System.ComponentModel.DataAnnotations;

namespace formsWeb.Models
{
    public class Questionnaire
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<string>? expression { get; set; }

        public List<double>? score { get; set; }


    }
}
