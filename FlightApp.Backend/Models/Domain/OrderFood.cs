namespace FlightApp.Backend.Models.Domain
{
    public class OrderFood
    {
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Food Food { get; set; }
        public int FoodId { get; set; }
    }
}
