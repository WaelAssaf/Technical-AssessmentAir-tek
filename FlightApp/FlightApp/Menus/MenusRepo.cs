using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Menus
{
    public class MenusRepo
    {
        public int DisplayAndReadMainMenu(Menu menu)
        {
            Console.WriteLine(menu.Title);

            foreach (var item in menu.Options)
            {
                Console.WriteLine(item);
            }

            Console.Write("\nPress any key to return to the Main Menu");
            Console.ReadKey();

            return 0;
        }

        public virtual int DisplayAndRead(Menu menu)
        {
            Console.Clear();
            Console.WriteLine("******* " + menu.Title + " *******\n");

            foreach (var item in menu.Options)
            {
                Console.WriteLine(item);
            }

            Console.Write("\nChoose an option: ");

            int intInput;
            int.TryParse(Console.ReadLine(), out intInput);

            return intInput;
        }

        public static Menu GetMainMenu()
        {
            var menu = new Menu();
            List<string> options = new List<string>();

            options.Add("1. Load a specific schedule from file");
            options.Add("2. Print the loaded schedules");
            options.Add("3. Generate flight itineraries");

            menu.Title = "Welcome to the Flight App Management System";
            menu.Options = options;


            menu.ExitMenu = menu.Options.Count + 1;
            menu.Options.Add(menu.ExitMenu + ". Exit");

            return menu;
        }
    }
}
