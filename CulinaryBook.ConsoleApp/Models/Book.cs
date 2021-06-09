using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBook.ConsoleApp.Models
{
    [Table("BOOK")]
    public class Book : DbObjectWithName
    {
        public Book()
        {
            RecipesLists = new List<RecipesList>();
        }
        public IList<RecipesList> RecipesLists { get; set; }
    }
}