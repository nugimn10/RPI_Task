using System;
using Microsoft.EntityFrameworkCore;
using UserServices.Domain.Entities;

namespace UserServices.Infrastructure.Presistences
{
    public class user_context : DbContext
    {
        public user_context(DbContextOptions<user_context> options) : base(options) {}

        public DbSet<Users> Users {get; set;}

        protected override void OnModelCreating(ModelBuilder model)
        {
            
            model.Entity<Notification_logs>()
            .HasOne(i => i.users)
            .WithMany().HasForeignKey(i => i.from);
        }
        
    }
}