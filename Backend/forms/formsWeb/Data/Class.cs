using formsWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace formsWeb.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Questionnaire> Questionnaire { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionTranslation> QuestionTranslations { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        
        public DbSet<Radio_Answer_Translation> Radio_Answer_Translations { get; set; }

        public DbSet<Answer_map> Answer_Maps { get; set; }
        public DbSet <Record> Records { get; set; }

        public DbSet <Form> Forms { get; set; }
        public DbSet<CheckBox_Answer_Translation> CheckBox_Answer_Translations { get; set; }
        
        
    }

    
}
