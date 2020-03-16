using System;
using Microsoft.EntityFrameworkCore;
using RPI_Task.Domain.Entities;

namespace RPI_Task.Presistences
{
    public class notification_context : DbContext
    {
        public notification_context(DbContextOptions<notification_context> options) : base(options) {}
        public DbSet<NotificationTB> Notification {get; set;}
        public DbSet<Notification_logsTB> Notification_Logs {get; set;}
        // public DbSet<Users> Users {get; set;}

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Notification_logsTB>()
            .HasOne(i => i.notification)
            .WithMany().HasForeignKey(i => i.notification_id);
            
            // model.Entity<Notification_logs>()
            // .HasOne(i => i.users)
            // .WithMany().HasForeignKey(i => i.from);
        }
        
    }
}