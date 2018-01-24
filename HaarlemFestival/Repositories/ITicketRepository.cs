using HaarlemFestival.Model;
using System;

namespace HaarlemFestival.Repositories
{
    interface ITicketRepository
    {
        Ticket GetTicket(Activity activity, DateTime startTime, TicketType ticketType);
    }
}
