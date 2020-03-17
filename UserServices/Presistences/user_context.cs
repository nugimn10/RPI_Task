using System;
using Microsoft.EntityFrameworkCore;
using UserServices.Domain.Entities;

namespace UserServices.Presistences
{
    public class usr_context : DbContext
    {
        public usr_context(DbContextOptions<usr_context> options) : base(options) {}

        public DbSet<UsersTB> Users {get; set;}

        
        
    }
}