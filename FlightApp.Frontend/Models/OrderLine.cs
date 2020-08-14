using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Frontend.Models
{
    public class OrderLine
    {
        public int OrderId { get; set; }
        public Food Food { get; set; }
        public int Quantity { get; set; }
    }
}
