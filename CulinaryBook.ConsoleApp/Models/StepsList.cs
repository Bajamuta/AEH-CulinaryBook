using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBook.ConsoleApp.Models
{
    [Table("STEPS_LIST")]
    public class StepsList : DbObject
    {
        [ForeignKey("Step")] 
        public int Id_Step { get; set; }
        public Step Step { get; set; }

        [Required] 
        public int Step_Number { get; set; }

        [ForeignKey("Recipe")]
        public int Id_Recipe { get; set; }
        public Recipe Recipe { get; set; }
    }
}