using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Data.Repositories.Concrete
{
    public class ChannelRepository : IChannelRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Message> _messages;
        private readonly DbSet<Channel> _channels;


        public ChannelRepository(ApplicationDbContext dbContext)
        {
            _messages = dbContext.Messages;
            _channels = dbContext.Channels;
            _context = dbContext;
        }
        public Message AddMessage(Message message)
        {
            _messages.Add(message);
            return message;
        }

        public Channel GetAllMessagesFromChannel(int channelId)
        {
            return _channels.Include(m => m.Messages).ThenInclude(p => p.Passenger).SingleOrDefault(c => c.ChannelId == channelId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
