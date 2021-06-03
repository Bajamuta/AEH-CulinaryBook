using System.ComponentModel.DataAnnotations;

namespace CulinaryBook.ConsoleApp.Models
{
    public class DbObjectWithName : DbObject
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
    }
}