using FlightApp.Frontend.Common;
using FlightApp.Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Frontend.ViewModels
{
    public class FoodViewModel
    {
        public ObservableCollection<Food> Foods { get; set; }

        public FoodViewModel()
        {
            Foods = new ObservableCollection<Food>();
            GetFoodFromAPI();
        }

        private async void GetFoodFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri($"http://localhost:60177/api/Food"));
            var foods = JsonConvert.DeserializeObject<ObservableCollection<Food>>(json);
            
            foreach(Food food in foods)
            {
                Foods.Add(food);
            }
        }
    }
}
