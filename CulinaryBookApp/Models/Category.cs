using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBookApp.Models
{
    [Table("CATEGORY")]
    public class Category : DbObject
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public IList<RecipesList> RecipesLists { get; set; }
    }
}