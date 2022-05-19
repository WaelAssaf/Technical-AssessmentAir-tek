using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Flights
{
    public class Flight
    {
        public int Capacity { get; private set; }
        public Schedule.Schedule Schedule { get; private set; }
        public List<Order.Order> Orders { get; set; }

        public Flight(int capacity, Schedule.Schedule schedule)
        {
            Capacity = capacity;
            schedule.is_loaded = true;
            Schedule = schedule;
            Orders = new List<Order.Order>();
        }
    }
}
