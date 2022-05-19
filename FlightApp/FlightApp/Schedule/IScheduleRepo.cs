using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Schedule
{
    public interface IScheduleRepo
    {
        List<Schedule> listSchedulesJson();
    }
}
