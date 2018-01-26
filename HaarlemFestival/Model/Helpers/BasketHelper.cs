﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model.Helpers
{
    public class BasketHelper
    {
        private BasketHelper uniqueInstance;

        private BasketHelper() { }

        public BasketHelper getInstance()
        {
            if(uniqueInstance == null)
            {
                uniqueInstance = new BasketHelper();
            }

            return uniqueInstance;
        }

        public void checkCookie(HttpContextBase context)
        {
            Order sessionOrder = (Order)context.Session["order"];
            HttpCookie ticketCookie = context.Request.Cookies["userCookie"];

            if (sessionOrder != null)
            {
                ticketCookie = new HttpCookie("userCookie", "0");
                int ticketValue = sessionOrder.OrderHasTickets.Count;
                ticketCookie.Value = ticketValue.ToString();
            }

            ticketCookie.Expires = DateTime.Now.AddDays(1);
            context.Response.SetCookie(ticketCookie);
        }
    }
}