using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerClientDemo.Entities
{
    /// <summary>
    /// 某游客某时间段内的行程
    /// </summary>
    public class Schedule
    {
        public User user { get; set; }
        public List<Point> points { get; set; }
    }
}
