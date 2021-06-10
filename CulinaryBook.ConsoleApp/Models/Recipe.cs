using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBook.ConsoleApp.Models
{
    [Table("RECIPE")]
    public class Recipe : DbObjectWithName
    {
        public string Photo { get; set; }
        
        [ForeignKey("Author")]
        [Required]
        public int Id_Author { get; set; }
        public Author Author { get; set; }
        
        public IngredientsList IngredientsList { get; set; }
        public StepsList StepsList { get; set; }
    }
}