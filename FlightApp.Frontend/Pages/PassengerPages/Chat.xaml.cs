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
        public PassengerViewModel PassengerViewModel { get; set; }

        public Chat()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PassengerViewModel = (PassengerViewModel)e.Parameter;
            ChatViewModel = new ChatViewModel(PassengerViewModel.Id);
            lvMyMessages.ItemsSource = ChatViewModel.Messages;
        }

        private async void SendMessage(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var message = new Message(PassengerViewModel.Id, PassengerViewModel.Name, tbInput.Text);
            await ChatViewModel.AddMessageAsync(PassengerViewModel.Id, tbInput.Text);
            ChatViewModel.Messages.Add(message);
            tbInput.Text = "";
        }
    }
}
