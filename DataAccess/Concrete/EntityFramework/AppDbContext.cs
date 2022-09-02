using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concret.EntityFramework
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DOTNETDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<Banner> Banners { get; set; } 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<About> About { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<PacketCategory> PacketCategories { get; set; }
        public DbSet<Packet> Packets { get; set; }
        public DbSet<Roles> Roles { get; set; } 
        public DbSet<Team> Teams { get; set; }
        public DbSet<Client> Clients { get; set; }  
        public DbSet<Location> Location { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
