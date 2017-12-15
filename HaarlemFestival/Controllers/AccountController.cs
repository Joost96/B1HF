using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival.Model;
using System.Web.Security;
using HaarlemFestival.Repositories;

namespace HaarlemFestival.Controllers
{
    public class AccountController : Controller
    {
        private DBHF db;
        private IAccountRepository accountRepository;
        private IPageRepository pageRepository;

        public AccountController()
        {
            db = new DBHF();
            accountRepository = new AccountRepository(db);
            pageRepository = new PageRepository(db);
        }

        // GET: login
        public ActionResult Login()
        {
            return View();
        }

        // POST: login
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Account account = accountRepository.GetAccount(model.Email, model.Password);
                if (account != null)
                {
                    FormsAuthentication.SetAuthCookie(account.Id.ToString(), false);

                    Session["loggedin_account"] = account;

                    return RedirectToAction("Index", "ContentManagement");
                }
                else
                {
                    ModelState.AddModelError("login-error", "The username or password is incorrect");
                }
            }
            return View(model);
        }

        // GET: register
        public ActionResult Register()
        {
            return View();
        }

        // POST: login
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Account checkAccount = accountRepository.GetAccount(model.Email);
                if (checkAccount == null)
                {
                    Account account = new Customer(model.Email,model.FirstName,model.LastName,model.Password,model.Country);
                    accountRepository.Register(account);

                    FormsAuthentication.SetAuthCookie(account.Id.ToString(), false);

                    Session["loggedin_account"] = account;

                    return RedirectToAction("Index", "ContentManagement");
                }
                else
                {
                    ModelState.AddModelError("register-error", "The username is already taken");
                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["loggedin_account"] = null;

            return RedirectToAction("Login", "Account");
        }
    }
}
