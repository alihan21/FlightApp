using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Frontend.Models
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
