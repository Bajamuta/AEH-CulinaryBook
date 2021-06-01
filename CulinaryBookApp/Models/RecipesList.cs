using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBookApp.Models
{
    [Table("RECIPES_LIST")]
    public class RecipesList : DbObject
    {
        [ForeignKey("RECIPE")]
        public int Id_Recipe { get; set; }
        public Recipe Recipe { get; set; }
        
        [ForeignKey("CATEGORY")]
        public int Id_Category { get; set; }
        public Category Category { get; set; }
        
        [ForeignKey("BOOK")]
        public int Id_Book { get; set; }
        public Book Book { get; set; }
    }
}