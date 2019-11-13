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

        void Add(User user);

        void Delete(User user);

        void Update(User user);

        void SaveChanges();
    }
}
