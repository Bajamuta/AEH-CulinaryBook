using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CulinaryBookApp.Models;

namespace CulinaryBookApp
{
    [Table("AUTHOR")]
    public class Author : DbObject
    {
        /*[Key]
        public int ID { get; set; }*/
        
        // TODO add enum types
        [Required]
        public string TYPE { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string NAME { get; set; }
        
        [Required]
        public string LOGIN { get; set; }
        
        [Required]
        public string PASSWORD { get; set; }
        
        [Required]
        public string DESCRIPTION { get; set; }
        
        [Required]
        [Display(Name =  "Office e-mail")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid e-mail format")]
        public string EMAIL { get; set; }
    }
}