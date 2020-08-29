namespace FlightApp.Frontend.Models
{
  public class Staff : User
  {
    public int LoginCode { get; set; }

    public Staff(int loginCode, string name) : base(name)
    {
      LoginCode = loginCode;
    }

    protected Staff()
    {
    }

    public void MovePassengerToAnotherSeat(Passenger passenger, Seat seat)
    {
      passenger.Seat = seat;
    }
  }
}
