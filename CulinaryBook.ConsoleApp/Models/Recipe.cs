using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBook.ConsoleApp.Models
{
    [Table("RECIPE")]
    public class Recipe : DbObjectWithName
    {
        public Recipe()
        {
            IngredientsLists = new List<IngredientsList>();
            RecipesLists = new List<RecipesList>();
            StepsLists = new List<StepsList>();
        }
        public string Photo { get; set; }
        
        [ForeignKey("Author")]
        [Required]
        public int Id_Author { get; set; }
        public Author Author { get; set; }
        
        public IList<IngredientsList> IngredientsLists { get; set; }
        public IList<RecipesList> RecipesLists { get; set; }
        public IList<StepsList> StepsLists { get; set; }
    }
}