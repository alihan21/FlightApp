using FlightApp.Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Frontend.ViewModels
{
    public class NotificationViewModel
    {
        public string Text { get; set; }
        public string Type { get; set; }
        public Notification Notification { get; set; }
        public bool isNotificationRead { get; set; }


        public async Task GetNotification(int passengerId)
        {
            HttpClient httpClient = new HttpClient();
            Passenger passenger;

            try
            {
                var res = await httpClient.GetAsync(new Uri($"http://localhost:60177/api/Notification/passenger/{passengerId}/notification"));


                if (res.IsSuccessStatusCode)
                {
                    passenger = JsonConvert.DeserializeObject<Passenger>(res.Content.ReadAsStringAsync().Result);

                    Notification = passenger.Notification;
                    isNotificationRead = passenger.IsNotificationRead;
                }

            }
            finally
            {
                httpClient.Dispose();
            }
        }

        public async void AddNotificationAsync(string flightId)
        {
            HttpClient httpClient = new HttpClient();

            var notificationJson = JsonConvert.SerializeObject(this);

            var res = await httpClient.PostAsync($"http://localhost:60177/api/Notification/flight/{flightId}/passengers/all/notification/add", new StringContent(notificationJson,
                Encoding.UTF8, "application/json"));
        }

        public async void AddNotificianToPassengerAsync(int passengerId)
        {
            HttpClient httpClient = new HttpClient();

            var notificationJson = JsonConvert.SerializeObject(this);

            var res = await httpClient.PostAsync($"http://localhost:60177/api/Notification/flight/passengers/{passengerId}/notification/add", new StringContent(notificationJson,
                Encoding.UTF8, "application/json"));
        }

        public async void NotificationIsRead(int passengerId)
        {
            HttpClient httpClient = new HttpClient();
        
            var res = await httpClient.PutAsync($"http://localhost:60177/api/Notification/flight/passengers/{passengerId}/notification/delete", new StringContent("",
                Encoding.UTF8, "application/json"));
        }
    }
}