using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerClientDemo.Entities
{
    public class LostContact
    {
        public User user { get; set; }
        public string searchMoment { get; set; }
        public string state { get; set; }

        public int? grade { get; set; }
        public int? isSolved { get; set; }
    }
}
