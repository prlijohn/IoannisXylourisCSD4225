using System.ComponentModel.DataAnnotations;
namespace formsWeb.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }
        /*
        [Required]
        public int age  { get; set;}

        [Required]
        public 
        */
        [Required]
        public string history { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

       
    }
}
