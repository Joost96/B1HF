using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class DBHF : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DBHF() : base("name=DBHF")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityDescription> ActivityDescription { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHasTickets> OrderHasTickets { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageDescription> PageDescriptions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

    }
}
