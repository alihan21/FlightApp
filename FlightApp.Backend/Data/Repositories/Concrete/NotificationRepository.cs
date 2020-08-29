using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FlightApp.Backend.Data.Repositories.Concrete
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly DbSet<Notification> _notifications;
        private readonly ApplicationDbContext _dbContext;

        public NotificationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _notifications = dbContext.Notification;
        }

        public void Add(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void Remove(Notification notification)
        {
            _notifications.Remove(notification);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
