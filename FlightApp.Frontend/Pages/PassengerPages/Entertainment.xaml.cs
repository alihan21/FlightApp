using FlightApp.Frontend.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace FlightApp.Frontend.Pages.PassengerPages
{
    /// <summary>
    /// Page where a passenger can entertain himself (by watching movies, series and or listening to music)
    /// </summary>
    public sealed partial class Entertainment : Page
    {
        public MoviesViewModel MoviesViewModel { get; set; }

        public Entertainment()
        {
            MoviesViewModel = new MoviesViewModel();
            this.InitializeComponent();
            LayoutRoot.DataContext = new CollectionViewSource { Source = MoviesViewModel.Movies };
        }
    }
}
