using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToaNhaQuocHoi.API.Models
{
    public class Face_Block
    {
        [Display(Name = "Mã mặt phẳng")]
        public int IDF { get; set; }

        [Display(Name = "Mã khối")]
        public int IDB { get; set; }

        public Face Face { get; set; }
        public Block Block { get; set; }
    }
}
