﻿using FlightApp.Backend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Data.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        void Add(Notification notification);
        void Remove(Notification notification);
        void SaveChanges();
    }
}
