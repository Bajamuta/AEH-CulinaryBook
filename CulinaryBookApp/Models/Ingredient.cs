using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBookApp.Models
{
    [Table("INGREDIENT")]
    public class Ingredient : DbObject
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        
        [Required]
        public string Junit { get; set; }
        
        public IList<IngredientsList> IngredientsLists { get; set; }
    }
}