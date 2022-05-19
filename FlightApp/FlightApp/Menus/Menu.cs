using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Menus
{
    public class Menu
    {
        public string Title { get; set; }
        public List<string> Options { get; set; }
        public int ExitMenu { get; set; }

        public Menu()
        {
            Options = new List<string>();
        }
    }
}
