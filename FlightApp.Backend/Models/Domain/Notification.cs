using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }

        public Notification(string text, string type)
        {
            Text = text;
            Type = type;
        }
    }
}
