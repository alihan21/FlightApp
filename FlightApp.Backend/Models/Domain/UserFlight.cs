namespace FlightApp.Backend.Models.Domain
{
  public class UserFlight
  {
    public int UserId { get; set; }
    public User User { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; }

    public UserFlight(User user, Flight flight)
    {
      User = user;
      UserId = user.UserId;
      Flight = flight;
      FlightId = flight.FlightId;
    }

    protected UserFlight()
    {

    }
  }
}
