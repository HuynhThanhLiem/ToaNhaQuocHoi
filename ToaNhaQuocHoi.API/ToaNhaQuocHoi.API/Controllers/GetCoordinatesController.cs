using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToaNhaQuocHoi.API.Data;
using ToaNhaQuocHoi.API.Models;
using ToaNhaQuocHoi.API.Models.GEOJson;

namespace ToaNhaQuocHoi.API.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    public class GetCoordinatesController : ControllerBase
    {
        private readonly GisAppDbContext _context;
        public GetCoordinatesController(GisAppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public string GetCoodinates(int id)
        {
            var blocks = _context.Blocks.Where(x => x.IDBT == id).ToArray();

            GEOJsonFormat geoFile = new GEOJsonFormat();

            geoFile.type = "FeatureCollection";
            geoFile.generator = "overpass-ide";
            geoFile.copyright = "The data included in this document is from www.openstreetmap.org. The data is made available under ODbL.";
            geoFile.timestamp = "2021-12-11T02:23:20Z";

            var ftres = new List<Features>();
            foreach (var b in blocks)
            {
                var feature = new Features();

                //Add Id & Type
                feature.id = b.IDB.ToString();
                feature.type = "Feature";


                //Add Properties
                properties _properties = new properties();
          
                var _blocktype = _context.BlockTypes.ToArray().Where(x => x.IDBT == b.IDBT).FirstOrDefault();
                _properties.id = b.IDB.ToString();
                _properties.blockName = _blocktype.blockName;
                _properties.height = _blocktype.height;
                feature.properties = _properties;

                //Add Geometry
                geometry _geometry = new geometry();
                _geometry.type = "Polygon";
                
                //Find IDF from IDB
                var getFace = _context.Blocks.Join(_context.Face_Blocks,
                b => b.IDB,
                fb => fb.IDB,
                (b, fb) => new
                {
                    fb.IDF,
                    b.IDB,
                }).Where(kq => kq.IDB == b.IDB).Select(kq => kq.IDF).ToArray();

                //Find IDN from IDF
                var nodes = _context.Nodes.Join(_context.Face_Nodes,
                    n => n.IDN,
                    fn => fn.IDN,
                    (n, fn) => new
                    {
                        fn.IDF,
                        n.x,
                        n.y,
                        n.z,
                        fn.seq,
                    }).Where(kq => kq.IDF == getFace[0]).OrderBy(kq => kq.seq).ToArray();

                List<double[]> coordinate = new List<double[]>();

                foreach (var node in nodes)
                {
                    double[] _node = new double[3] { (double)node.x, (double)node.y, (double)node.z };
                    coordinate.Add(_node);
                }

                List<List<double[]>> lstNode = new List<List<double[]>>();
                lstNode.Add(coordinate);

                _geometry.coordinates = lstNode;
                feature.geometry = _geometry;


                //Add feature to list feature
                ftres.Add(feature);
            }

            geoFile.features = ftres;
            var jsonstring = Newtonsoft.Json.JsonConvert.SerializeObject(geoFile);
            return jsonstring;
        }

    }
}
