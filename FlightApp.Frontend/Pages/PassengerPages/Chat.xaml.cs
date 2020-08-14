using FlightApp.Frontend.Models;
using FlightApp.Frontend.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.PassengerPages
{
    /// <summary>
    /// Page where passengers (who travel together) can chat with each other
    /// </summary>
    public sealed partial class Chat : Page
    {

        public ChatViewModel ChatViewModel { get; set; }
        private Passenger CurrentPassenger { get; set; }

        public Chat()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CurrentPassenger = (Passenger)e.Parameter;
            ChatViewModel = new ChatViewModel(CurrentPassenger.UserId);
            MyMessages.ItemsSource = ChatViewModel.Messages;
        }

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var message = new Message(CurrentPassenger, Input.Text);
            await ChatViewModel.AddMessageAsync(CurrentPassenger.UserId, Input.Text);
            ChatViewModel.Messages.Add(message);
            Input.Text = "";
        }
    }
}
