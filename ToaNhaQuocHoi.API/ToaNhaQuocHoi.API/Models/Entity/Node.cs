using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToaNhaQuocHoi.API.Models
{
    public class Node
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDN { get; set; }

        [Required]
        [Display(Name = "x")]
        public double x { get; set; }

        [Required]
        [Display(Name = "y")]
        public double y { get; set; }

        [Required]
        [Display(Name = "z")]
        public double z { get; set; }

        public ICollection<Face_Node> Face_Nodes { get; set; }

    }
}
