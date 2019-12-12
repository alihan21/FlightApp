using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Frontend.Models
{
  public class Seat
  {
    public int SeatId { get; set; }
    public string SeatNumber { get; set; }

    public Seat(string seatNumber)
    {
      SeatNumber = seatNumber;
    }

    protected Seat()
    {

    }
  }
}
