using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBookApp.Models
{
    [Table("RECIPE")]
    public class Recipe : DbObject
    {
        [Required]
        public string Name { get; set; }
        
        public string Photo { get; set; }
        
        [ForeignKey("AUTHOR")]
        [Required]
        public int Id_Author { get; set; }

        public Author Author { get; set; }
        
        public IList<IngredientsList> IngredientsLists { get; set; }
    }
}