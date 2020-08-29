using FlightApp.Frontend.Common;
using FlightApp.Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media.Imaging;

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



            foreach (Food food in foods)
            {
                if (food.Image != null)
                {
                    var bytes = Convert.FromBase64String(food.Image);
                    var buf = bytes.AsBuffer();
                    var stream = buf.AsStream();

                    var image = stream.AsRandomAccessStream();

                    var decoder = await BitmapDecoder.CreateAsync(image);
                    image.Seek(0);

                    var output = new WriteableBitmap((int)decoder.PixelHeight, (int)decoder.PixelWidth);
                    await output.SetSourceAsync(image);

                    food.Source = output;
                }


                Foods.Add(food);
            }
        }

    }
}