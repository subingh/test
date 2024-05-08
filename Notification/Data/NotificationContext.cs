using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notification.Models;

namespace Notification.Data
{
    public class NotificationContext : DbContext
    {
        public NotificationContext (DbContextOptions<NotificationContext> options)
            : base(options)
        {
        }

        public DbSet<Notification.Models.MyClient> MyClient { get; set; } = default!;
    }
}
