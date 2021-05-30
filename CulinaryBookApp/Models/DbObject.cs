using System.ComponentModel.DataAnnotations;

namespace CulinaryBookApp.Models
{
    public class DbObject
    {
        [Key]
        public int ID { get; set; }
    }
}