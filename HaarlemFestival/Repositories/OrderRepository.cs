using HaarlemFestival.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        DBHF db;

        public OrderRepository(DBHF db)
        {
            this.db = db;
        }

        public void CreateOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public IEnumerable<Order> GetOrdersCustomer(int customerId)
        {
            return db.Orders
                .Include(o => o.OrderHasTickets
                    .Select(oht => oht.Ticket)
                        .Select(t => t.TimeSlot.Activity))
                .Where(o => o.CustomerId == customerId);
        }
    }
}