using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerClientDemo.Entities
{
    /// <summary>
    /// 某游客当前位置
    /// </summary>
    public class Tourist
    {
        public User user { get; set; }
        public Point point { get; set; }
    }
}
