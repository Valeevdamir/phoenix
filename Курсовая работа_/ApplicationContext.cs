using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace Курсовая_работа_
{
    [Keyless]
    public class ApplicationContext : DbContext
    {
        
        public DbSet<Driver> drivers { get; set; }
        public DbSet<Track> tracks { get; set; }
        public DbSet<Truck> trucks { get; set; }
        public DbSet<DATA> data { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=trump;Trusted_Connection=True;");
        }
    }
}