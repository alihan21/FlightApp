using Windows.UI.Xaml.Media;

namespace FlightApp.Frontend.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public ImageSource Source { get; set; }


        public Food(string name, string description, string type, decimal price)
        {
            Name = name;
            Description = description;
            Type = type;
            Price = price;
        }

        protected Food()
        {
        }
    }
}
