using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Schedule
{
    public class ScheduleRepo : IScheduleRepo
    {
        public List<Schedule> listSchedulesJson()
        {
            StreamReader r = new StreamReader("C:\\Users\\waelas\\Desktop\\Flights.json");
            string strjson = r.ReadToEnd();

            return JsonConvert.DeserializeObject<List<Schedule>>(strjson);
        }

        public static string LoadMessage(Schedule schedule)
        {
            return "Schedule " + schedule.flight_no.ToString() + " is loaded";
        }
    }
}
