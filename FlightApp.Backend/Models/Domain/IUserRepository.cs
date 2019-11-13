﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Models.Domain
{
    public interface IUserRepository
    {
        User GetBy(int id);

        IEnumerable<User> GetAll();

        void Update(User user);

        void SaveChanges();
    }
}