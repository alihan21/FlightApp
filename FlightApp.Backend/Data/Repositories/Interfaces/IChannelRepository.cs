﻿using FlightApp.Backend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Data.Repositories.Interfaces
{
    public interface IChannelRepository
    {

        Channel GetAllMessagesFromChannel(int channelId);
        Message AddMessage(Message message);
        void SaveChanges();
    }
}
