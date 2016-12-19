using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerClientDemo.Entities
{
    public class User
    {
        public string phoneNum { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public byte[] avatar { get; set; }
        public string description { get; set; }
        public string birthday { get; set; }
        public string registerTime { get; set; }
        public int? isPointOpen { get; set; }
    }
}
