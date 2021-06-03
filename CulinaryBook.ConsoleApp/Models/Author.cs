using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CulinaryBook.ConsoleApp.Models;

namespace CulinaryBook.ConsoleApp
{
    [Table("AUTHOR")]
    public class Author : DbObject
    {
       // We do not need the id parameter because we use DbObject
        // TODO add enum types
        [Required]
        public string Type { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        
        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        [Display(Name =  "Office e-mail")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid e-mail format")]
        public string Email { get; set; }

        public IList<Recipe> Recipes { get; set; }
    }
}