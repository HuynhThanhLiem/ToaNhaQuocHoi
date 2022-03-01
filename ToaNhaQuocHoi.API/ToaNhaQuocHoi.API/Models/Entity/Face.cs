using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToaNhaQuocHoi.API.Models
{
    public class Face
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDF { get; set; }

        [Required]
        [Display(Name = "Tên mặt")]
        public string faceName { get; set; }

        public ICollection<Face_Node> Face_Nodes { get; set; }
        public ICollection<Face_Block> Face_Blocks { get; set; }
    }
}
