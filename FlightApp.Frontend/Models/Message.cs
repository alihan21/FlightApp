namespace FlightApp.Frontend.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public int ChannelId { get; set; }
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        public Message()
        {

        }

        public Message(int passengerId, string text)
        {
            Text = text;
            PassengerId = passengerId;
        }

        public Message(int passengerId, string passengerName, string text)
        {
            Passenger = new Passenger();
            PassengerId = passengerId;
            Passenger.Name = passengerName;
            Text = text;
        }

    }

}
