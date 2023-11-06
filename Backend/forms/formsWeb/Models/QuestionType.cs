using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace formsWeb.Models
{
    public class QuestionType
    {
        [Key]
        public int Id { get; set; } 
        [Required, NotNull]
        public string Name { get; set; } = string.Empty;
    }
}
