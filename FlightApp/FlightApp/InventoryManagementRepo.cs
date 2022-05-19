using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightApp.Flights;
using FlightApp.Menus;
using FlightApp.Schedule;

namespace FlightApp
{
    public class InventoryManagementRepo
    {
        public List<Order.Order> Orders { get; set; }
        public List<Flight> FlightsScheduled { get; set; }
        public List<Schedule.Schedule> Schedules { get; set; }
        public FlightRepo flightrepo = new FlightRepo();

        public InventoryManagementRepo()
        {
            FlightsScheduled = new List<Flight>();
            Schedules = new Schedule.ScheduleRepo().listSchedulesJson();
        }

        public void ProcessFlightSchedule(int input)
        {
            //input > 0 will test if the user enters any character instead of integer.
            //input <= Schedules.Count will make sure that the user will not enter an option that does not exist
            if (input > 0 && input <= Schedules.Count)
            {
                var selectedSchedule = Schedules.FirstOrDefault(s => !s.is_loaded && s.flight_no == input);
                if (selectedSchedule != null)
                {
                    var scheduledFlight = new Flight(20, selectedSchedule);
                    FlightsScheduled.Add(scheduledFlight);
                    FlightsScheduled = FlightsScheduled.OrderBy(i => i.Schedule.flight_no).ToList();
                    DisplayScheduleLoadedMessage(selectedSchedule);
                }
            }
        }

        public void DisplayScheduleLoadedMessage(Schedule.Schedule schedule)
        {
            var menu = new Menu();
            List<string> options = new List<string>();
            options.Add(ScheduleRepo.LoadMessage(schedule));

            menu.Options = options;

            new MenusRepo().DisplayAndReadMainMenu(menu);
        }

        public void DisplayLoadedSchedules()
        {
            var menu = new Menu();
            menu.Title = "\n******* Loaded schedules *******\n";
            

            foreach (var flight in FlightsScheduled)
            {
                menu.Options.Add(flightrepo.DisplayFlightSchedule(flight.Schedule));
            }

            new MenusRepo().DisplayAndReadMainMenu(menu);
        }

        public void DisplayFlightItineraries()
        {
            //Load order from the JSON file
            LoadOrders();

            var menu = new Menu();
            menu.Title = "\n******* Flight itineraries*******\n";
      

            foreach (var order in Orders)
            {
                menu.Options.Add(ItineraryRepo.Itinerary(order));
            }

            new MenusRepo().DisplayAndReadMainMenu(menu);
        }

        private void LoadOrders()
        {
            Orders = new Order.OrderRepo().ImportOrdersFromJson().OrderBy(o => o.priority).ToList();

            foreach (var schedule in Schedules)
            {
                if (schedule.is_loaded)
                {
                    var loadedFlights = FlightsScheduled.Where(f => f.Schedule == schedule).ToList();

                    foreach (var flight in loadedFlights)
                    {
                        var flightOrders = Orders.Where(o => o.IsNotLoaded() && o.destination == schedule.arrival_city).Take(flight.Capacity).Select(o => { o.schedule = schedule; return o; }).ToList();
                        flight.Orders = flightOrders;
                    }
                }
            }
        }

        public Menu GetFlightScheduleMenu()
        {
            var menu = new Menu();
            menu.Title = "Choose a schedule to load";

     
            foreach (var item in Schedules)
            {
                if (!item.is_loaded)
                {
                    menu.Options.Add(item.flight_no.ToString() + "- From:'" + item.departure_city +"' TO '" +item.arrival_city + "' On Day " + item.day);
                }
            }

            menu.ExitMenu = Schedules.Count + 1;
            menu.Options.Add(menu.ExitMenu + ". Main menu");

            return menu;
        }
    }
}
