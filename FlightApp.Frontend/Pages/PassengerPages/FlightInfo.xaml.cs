using FlightApp.Frontend.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.PassengerPages
{
  /// <summary>
  /// Page where a passenger can check information about current flight
  /// </summary>
  public sealed partial class FlightInfo : Page
  {
    public FlightViewModel FlightViewModel { get; set; }

    public FlightInfo()
    {
      this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);
      int passengerId = 0;

      if (e.Parameter != null)
      {
        passengerId = (int)e.Parameter;

        FlightViewModel = new FlightViewModel(passengerId);
      }
    }
  }
}
