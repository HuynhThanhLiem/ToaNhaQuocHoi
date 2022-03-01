using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToaNhaQuocHoi.API.Models
{
    public class Block
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDB { get; set; }

        [Required]
        [Display(Name = "Mã loại khối")]
        public int IDBT { get; set; }

        [Required]
        [Display(Name = "Mô tả")]
        public string blockDesc { get; set; }

        [Required]
        [Display(Name = "Mã tòa")]
        public int IDBD { get; set; }

        [ForeignKey("IDBD")]
        public Building Building { get; set; }

        [ForeignKey("IDBT")]
        public BlockType BlockType { get; set; }

        public ICollection<Face_Block> Face_Blocks { get; set; }
    }
}
