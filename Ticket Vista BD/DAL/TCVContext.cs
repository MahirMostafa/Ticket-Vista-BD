using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class TCVContext : DbContext
    {
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Advertiser> Advertisers { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Salary> Salarys { get; set; }
        public DbSet<Advertise> Advertises { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }



    }
}
