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
            db.OrderHasTickets.AddRange(order.OrderHasTickets);
            foreach(OrderHasTickets oht in order.OrderHasTickets)
            {
                oht.Ticket.TimeSlot.OccupiedSeats += oht.Amount;
                db.Entry(oht.Ticket.TimeSlot).State = EntityState.Modified;
            }
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
        public IEnumerable<OrderHasTickets> getOrdersFromEvent(EventType type)
        {
            return db.OrderHasTickets.Include(oht => oht.Ticket.TimeSlot.Activity)
                .Include(oht => oht.Order.Customer)
                .Where(oht => oht.Ticket.TimeSlot.Activity.Type == type);//.Include(oht => oht.Ticket.TimeSlot)
        }
    }
}