using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBook.ConsoleApp.Models
{
    [Table("STEP")]
    public class Step : DbObject
    {
        public Step()
        {
            StepsLists = new List<StepsList>();
        }
        [Required]
        public string Description { get; set; }
        
        public IList<StepsList> StepsLists { get; set; }
    }
}