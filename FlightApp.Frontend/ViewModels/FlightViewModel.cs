using FlightApp.Frontend.Common;
using FlightApp.Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace FlightApp.Frontend.ViewModels
{
  public class FlightViewModel : BindableBase
  {
    private string _destination;

    public string Destination {
      get { return _destination; }
      set {
        if (value != _destination)
        {
          _destination = value;
          RaisePropertyChanged();
        }
      }
    }

    private string _origin;

    public string Origin {
      get { return _origin; }
      set {
        if (value != _origin)
        {
          _origin = value;
          RaisePropertyChanged();
        }
      }
    }

    private double _duration;

    public double Duration {
      get { return _duration; }
      set {
        if (value != _duration)
        {
          _duration = value;
          RaisePropertyChanged();
        }
      }
    }

    private DateTime _timeOfDepart;

    public DateTime TimeOfDepart {
      get { return _timeOfDepart; }
      set {
        if (value != _timeOfDepart)
        {
          _timeOfDepart = value;
          RaisePropertyChanged();
        }
      }
    }

    private int _planeMaxSeats;

    public int PlaneMaxSeats {
      get { return _planeMaxSeats; }
      set {
        if (value != _planeMaxSeats)
        {
          _planeMaxSeats = value;
          RaisePropertyChanged();
        }
      }
    }

    private string _planeName;

    public string PlaneName {
      get { return _planeName; }
      set {
        if (value != _planeName)
        {
          _planeName = value;
          RaisePropertyChanged();
        }
      }
    }

    public FlightViewModel()
    {

    }

    public FlightViewModel(int passengerId)
    {
      GetFlightFromAPI(passengerId);
    }

    private async void GetFlightFromAPI(int passengerId)
    {
      HttpClient client = new HttpClient();
      var json = await client.GetStringAsync(new Uri($"http://localhost:60177/api/UserFlight/user/{passengerId}"));
      var currentUserFlight = JsonConvert.DeserializeObject<UserFlight>(json);

      if (currentUserFlight != null)
      {
        var flight = currentUserFlight.Flight;

        Destination = flight.Destination;
        Origin = flight.Origin;
        Duration = flight.FlightDuration;
        TimeOfDepart = flight.TimeOfDepart;
        PlaneMaxSeats = flight.Plane.MaxSeats;
        PlaneName = flight.Plane.Name;
      }
    }
  }
}
