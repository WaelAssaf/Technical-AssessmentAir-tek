using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Order
{
    public interface IOrderRepo
    {
        List<Order> ImportOrdersFromJson();
    }
}
