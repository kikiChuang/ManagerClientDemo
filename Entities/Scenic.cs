using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerClientDemo.Entities
{
    public class Scenic
    {
        public string description { get; set; }
        public int id { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public string name { get; set; }
    }
}
