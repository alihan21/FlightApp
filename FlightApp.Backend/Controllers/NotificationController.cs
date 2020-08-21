using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using FlightApp.Backend.Models.DTO_s;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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


        [HttpGet("passenger/{passengerId}/notification/")]
        public ActionResult<Passenger> GetNotification(int passengerId)
        {
            var passenger = _passengerRepository.GetById(passengerId);

            if (passenger == null)
            {
                return NotFound("Passenger not found");
            }

            if(passenger.Notification == null)
            {
                return NotFound("Passenger does not have a notifcation");
            }

            return Ok(passenger);
        }

        [HttpPost("flight/{flightId}/passengers/all/notification/add")]
        public ActionResult<Notification> AddNotificationAllPassengers(string flightId, NotificationDTO model)
        {
            Notification notification = new Notification(model.Text, model.Type);
            _notificiationRepository.Add(notification);

            List<Passenger> passengers = _userFlightRepository.GetAllPassengersByFlightId(flightId).ToList();

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
        public ActionResult<Notification> AddNotificationSpecificPassenger(int passengerId, NotificationDTO model)
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

        [HttpPut("flight/passengers/{passengerId}/notification/delete")]
        public ActionResult EditNotification(int passengerId)
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