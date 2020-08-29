namespace FlightApp.Backend.Models.Domain
{
    public class OrderLine
    {
        public int OrderId { get; set; }
        public Food Food { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
    }
}
