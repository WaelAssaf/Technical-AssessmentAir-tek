using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Order
{
    public class OrderRepo : IOrderRepo
    {
        public List<Order> ImportOrdersFromJson()
        {
            StreamReader r = new StreamReader("C:\\Users\\waelas\\Downloads\\coding-assigment-orders.json");
            string strjson = r.ReadToEnd();

            var orders = JsonConvert.DeserializeObject<Dictionary<string, Order>>(strjson).Select(p =>
            new Order { order_no = p.Key, destination = p.Value.destination, priority = int.Parse(p.Key.Substring(p.Key.LastIndexOf('-') + 1)) }).ToList();

            return orders;
        }
    }
}
