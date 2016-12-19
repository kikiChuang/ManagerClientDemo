using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerClientDemo.Entities
{
    public class EmergencyCall
    {
        public int id { get; set; }
        public string phoneNum { get; set; }
        public string time { get; set; }
        public decimal? longitude { get; set; }
        public decimal? latitude { get; set; }
    }
}
