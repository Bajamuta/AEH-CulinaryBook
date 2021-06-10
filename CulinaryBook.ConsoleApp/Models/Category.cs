using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBook.ConsoleApp.Models
{
    [Table("CATEGORY")]
    public class Category : DbObjectWithName
    {
        [Required] public string Description { get; set; } = "";
    }
}