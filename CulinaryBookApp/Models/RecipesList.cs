using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBookApp.Models
{
    [Table("RECIPES_LIST")]
    public class RecipesList : DbObject
    {
        [ForeignKey("Recipe")]
        public int Id_Recipe { get; set; }
        public Recipe Recipe { get; set; }
        
        [ForeignKey("Category")]
        public int Id_Category { get; set; }
        public Category Category { get; set; }
        
        [ForeignKey("Book")]
        public int Id_Book { get; set; }
        public Book Book { get; set; }
    }
}