﻿using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace HaarlemFestival
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        // https://www.codeproject.com/Articles/578374/AplusBeginner-splusTutorialplusonplusCustomplusF
        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        string id = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        string role = "";
                        Account account;
                        IAccountRepository repository = new AccountRepository(new DBHF());
                        account = repository.GetAccount(id);
                        if (account.GetType() == typeof(Employee))
                        {
                            Employee employee = (Employee)account;
                            role = employee.EmployeeType.ToString();
                            HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new System.Security.Principal.GenericIdentity(id, "Forms"), (new string[] { role }));
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.GetType();
                    }
                }
            }
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session["language"] = Language.Eng;
            Session.Remove("order");

            //HttpCookie myCookie = Request.Cookies["userCookie"];
            //if (myCookie != null)
            //{

            //    myCookie.Expires = DateTime.Now.AddDays(-1d);
            //    Response.Cookies.Add(myCookie);
            //}
        }
    }
}
