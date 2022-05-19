using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FlightApp.Schedule;
using FlightApp.Menus;

namespace FlightApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inventory = new InventoryManagementRepo();

            GetUserInput(inventory);
        }

        private static void GetUserInput(InventoryManagementRepo inventory)
        {
            int userChoice;
            Menu menu = MenusRepo.GetMainMenu();

            do
            {
                userChoice = new MenusRepo().DisplayAndRead(menu);
                ProcessUserInputOfMainMenu(userChoice, inventory);
            } while (userChoice != menu.ExitMenu);
        }

        private static void ProcessUserInputOfMainMenu(int userChoice, InventoryManagementRepo inventory)
        {
            switch (userChoice)
            {
                case 1:
                    ReadFlightsSchedule(inventory);
                    break;
                case 2:
                    inventory.DisplayLoadedSchedules();
                    break;
                case 3:
                    inventory.DisplayFlightItineraries();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
            }
        }

        private static void ReadFlightsSchedule(InventoryManagementRepo inventory)
        {
            int input;
            Menu menu;

            do
            {
                menu = inventory.GetFlightScheduleMenu();
                input = new MenusRepo().DisplayAndRead(menu);
                inventory.ProcessFlightSchedule(input);
            }
            while (input != menu.ExitMenu);
        }
 
    }
}
