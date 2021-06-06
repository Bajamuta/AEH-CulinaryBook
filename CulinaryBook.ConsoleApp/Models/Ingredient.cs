using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBook.ConsoleApp.Models
{
    [Table("INGREDIENT")]
    public class Ingredient : DbObjectWithName
    {
        public Ingredient()
        {
            IngredientsLists = new List<IngredientsList>();
        }

        [Required]
        public string Junit { get; set; }
        
        public IList<IngredientsList> IngredientsLists { get; set; }
    }
}