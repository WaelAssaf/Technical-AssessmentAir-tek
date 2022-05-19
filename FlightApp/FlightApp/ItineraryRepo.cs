using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp
{
    public class ItineraryRepo
    {
        public static string Itinerary(Order.Order order)
        {
            return order.IsNotLoaded() ? "order:"+ order.order_no +", flightNumber: not scheduled"
                : "order: "+ order.order_no + 
                ", flightNumber: " + order.schedule.flight_no + 
                ", departure: " + order.schedule.departure_city + 
                ", arrival: " + order.schedule.arrival_city + 
                ", day: " +  order.schedule.day;
        }
    }
}
