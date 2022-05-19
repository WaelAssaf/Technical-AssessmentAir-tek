using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Order
{
    public class Order
    {
        public int priority { get; set; }
        public string order_no { get; set; }
        public string destination { get; set; }
        public Schedule.Schedule schedule { get; set; }

        public bool IsNotLoaded()
        {
            return schedule == null;
        }
    }
}
