using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Flights
{
    public class FlightRepo
    {
        public string DisplayFlightSchedule(Schedule.Schedule sch)
        {
            return "Flight: " + sch.flight_no
                    + ", departure: " + sch.departure_city
                    + ", arrival: " + sch.arrival_city
                    + ", day: " + sch.day;
        }
    }
}
