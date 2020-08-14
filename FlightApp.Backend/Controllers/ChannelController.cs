using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using FlightApp.Backend.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightApp.Backend.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IChannelRepository _channelRepository;


        public ChannelController(IUserRepository userRepository, IChannelRepository channelRepository)
        {
            _userRepository = userRepository;
            _channelRepository = channelRepository;
        }

        [HttpGet("{id}")]
        public IEnumerable<Message> GetChannelWithMessages(int id)
        {
            Passenger user = _userRepository.GetPassengerByIdWithChannel(id);

            Channel channel = _channelRepository.GetAllMessagesFromChannel(user.ChannelId);

            return channel.Messages;
        }

        [HttpGet]
        [Route("{passengerId}/Message/{text}")]
        public ActionResult<MessageDTO> CreateMessage(int passengerId, string text)
        {
            Passenger user = _userRepository.GetPassengerByIdWithChannel(passengerId);
            Message message = new Message(user, text);
            _channelRepository.AddMessage(message);
            _channelRepository.SaveChanges();
            return new MessageDTO(message);
        }
    }
}