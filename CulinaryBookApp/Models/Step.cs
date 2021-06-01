using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBookApp.Models
{
    [Table("STEP")]
    public class Step : DbObject
    {
        [Required]
        public string Description { get; set; }
        
        public IList<StepsList> StepsLists { get; set; }
    }
}