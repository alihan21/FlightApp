using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Frontend.ViewModels
{
    public class NotificationViewModel
    {
        public string Text { get; set; }
        public string Type { get; set; }

        public async void AddNotificationAsync(string flightId)
        {
            HttpClient httpClient = new HttpClient();

            var notificationJson = JsonConvert.SerializeObject(this);

            var res = await httpClient.PostAsync($"http://localhost:60177/api/Notification/flight/{flightId}/passengers/notification/add", new StringContent(notificationJson,
                Encoding.UTF8, "application/json"));
        }
    }
}
