using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace formsWeb.Models.ViewModel
{
    public class QuestionnaireViewModel
    {
        
        public List<SelectListItem>? QuestSelectList { get; set; }

        [ForeignKey("Questionnaire")]
        public int QuestSelected { get; set; }
        public Questionnaire Questionnaire { get; set; }
    }
}
