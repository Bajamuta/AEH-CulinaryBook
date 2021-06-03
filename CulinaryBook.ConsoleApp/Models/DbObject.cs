using System.ComponentModel.DataAnnotations;

namespace CulinaryBook.ConsoleApp.Models
{
    public class DbObject
    {
        [Key]
        public int ID { get; set; }
    }
}