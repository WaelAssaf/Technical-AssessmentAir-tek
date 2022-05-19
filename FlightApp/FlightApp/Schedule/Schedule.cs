using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Schedule
{
    public class Schedule
    {
        public int flight_no { get; set; }
        public string departure_city { get; set; }
        public string arrival_city { get; set; }
        public int day { get; set; }
        public bool is_loaded { get; set; }
    }
}
