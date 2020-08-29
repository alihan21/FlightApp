using FlightApp.Frontend.Common;
using FlightApp.Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace FlightApp.Frontend.ViewModels
{
    public class ChatViewModel : BindableBase
    {

        public ObservableCollection<Message> Messages { get; set; }

        public ChatViewModel()
        {

        }

        public ChatViewModel(int passengerId)
        {
            Messages = new ObservableCollection<Message>();
            loadDataAsync(passengerId);
        }

        private async void loadDataAsync(int passengerId)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri($"http://localhost:60177/api/Channel/{passengerId}"));
            var messageList = JsonConvert.DeserializeObject<IList<Message>>(json);
            foreach (var message in messageList)
            {
                Messages.Add(message);
            }
        }

        public async Task AddMessageAsync(int passengerId, string text)
        {
            // TODO: Find another serialize for Order object
            HttpClient client = new HttpClient();
            var res = await client.GetStringAsync(new Uri($"http://localhost:60177/api/Channel/{passengerId}/Message/{text}"));

        }
    }
}
