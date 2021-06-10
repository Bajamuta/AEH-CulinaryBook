using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBook.ConsoleApp.Models
{
    [Table("INGREDIENT")]
    public class Ingredient : DbObjectWithName
    {
        [Required]
        public string Junit { get; set; }
    }
}