using HaarlemFestival.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersCustomer(int customerId);
        IEnumerable<OrderHasTickets> getOrdersFromEvent(EventType type);
        void CreateOrder(Order order);
    }
}