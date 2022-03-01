using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToaNhaQuocHoi.API.Models.GEOJson
{
    public class geometry
    {
        public string type { get; set; }
        public List<List<double[]>> coordinates { get; set; }
    }
}
