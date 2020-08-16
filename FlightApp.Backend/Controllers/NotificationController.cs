using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using FlightApp.Backend.Models.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace FlightApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly INotificationRepository _notificiationRepository;
        private readonly IUserFlightRepository _userFlightRepository;
        private readonly IPassengerRepository _passengerRepository;

        public NotificationController(INotificationRepository notificationRepository, IUserFlightRepository userFlightRepository, IPassengerRepository passengerRepository)
        {
            _notificiationRepository = notificationRepository;
            _userFlightRepository = userFlightRepository;
            _passengerRepository = passengerRepository;
        }

        [HttpPost("flight/{flightId}/passengers/notification/add")]
        public ActionResult<Notification> AddNotification(string flightId, NotificationDTO model)
        {
            Notification notification = new Notification(model.Text, model.Type);
            _notificiationRepository.Add(notification);

            var passengers = _userFlightRepository.GetPassengersByFlightId(flightId);

            if (passengers == null)
            {
                return NotFound("Flight not found");
            }

            foreach (Passenger passenger in passengers)
            {
                passenger.Notification = notification;
                passenger.IsNotificationRead = false;
            }

            _notificiationRepository.SaveChanges();
            _passengerRepository.SaveChanges();

            return Ok();
        }

        [HttpPost("flight/passengers/{passengerId}/notification/add")]
        public ActionResult<Notification> AddNotification(int passengerId, NotificationDTO model)
        {
            Notification notification = new Notification(model.Text, model.Type);
            _notificiationRepository.Add(notification);

            var passenger = _passengerRepository.GetById(passengerId);

            if (passenger == null)
            {
                return NotFound("Passenger not found");
            }

            passenger.Notification = notification;
            passenger.IsNotificationRead = false;

            _notificiationRepository.SaveChanges();
            _passengerRepository.SaveChanges();

            return Ok();
        }

        [HttpDelete("flight/passengers/{passengerId}/notification/delete")]
        public ActionResult RemoveNotification(int passengerId)
        {
            var passenger = _passengerRepository.GetById(passengerId);

            if (passenger == null)
            {
                return NotFound("Passenger not found");
            }

            passenger.IsNotificationRead = true;

            _passengerRepository.SaveChanges();

            return Ok(passenger);
        }
    }
}