using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBook.ConsoleApp.Models
{
    public enum Type
    {
        Admin, User, Test
    }
    
    [Table("AUTHOR")]
    public class Author : DbObjectWithName
    {
       // We do not need the id parameter because we use DbObject
        public Author()
        {
            Recipes = new List<Recipe>();
        }
        
        [Required]
        public Type Type { get; set; }

        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required] public string Description { get; set; } = "";
        
        [Required]
        [Display(Name =  "Office e-mail")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid e-mail format")]
        public string Email { get; set; }

        public IList<Recipe> Recipes { get; set; }
    }
}