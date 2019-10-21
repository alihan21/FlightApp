namespace FlightApp.Backend.Models.Domain
{
    public class StaffFlight
    {
        public Flight Flight { get; set; }
        public int FlightId { get; set; }
        public Staff Staff { get; set; }
        public int StaffId { get; set; }
    }
}
