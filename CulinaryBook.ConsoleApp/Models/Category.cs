using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBook.ConsoleApp.Models
{
    [Table("CATEGORY")]
    public class Category : DbObjectWithName
    {
        public Category()
        {
            RecipesLists = new List<RecipesList>();
        }

        [Required] public string Description { get; set; } = "";
        
        public IList<RecipesList> RecipesLists { get; set; }
    }
}