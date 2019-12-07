using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
  public class Chatroom
  {
    public string LoginCode { get; set; }
    public List<Passenger> Users { get; set; }

    public Chatroom(string loginCode)
    {
      LoginCode = loginCode;
      Users = new List<Passenger>();
    }

    protected Chatroom()
    {
      Users = new List<Passenger>();
    }

    public void AddUserToChatroom(Passenger passenger)
    {
      Users.Add(passenger);
    }

    public void RemoveUserFromChatroom(Passenger passenger)
    {
      Users.Remove(passenger);
    }
  }
}
