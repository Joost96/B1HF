using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using HaarlemFestival.Model;

namespace HaarlemFestival.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private DBHF db;

        public TicketRepository(DBHF db)
        {
            this.db = db;
        }

        public Ticket GetTicket(Activity activity, DateTime startTime, TicketType ticketType)
        {
            return db.Tickets.Where(t => t.TimeSlot_StartTime == startTime && t.TimeSlot_Activity_Id == activity.Id && t.Type == ticketType).SingleOrDefault();
        }
    }
}