using Communal1.Services;
using Communal1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Communal1.Controllers
{
    public class SecurityController : Controller
    {
        private ISecurityService _service = null;
        public SecurityController(ISecurityService service) 
        {
            _service = service;
        }
        // GET: Security
        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(LogonViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_service.IsValidUser(model))
                {
                    this.Session.Add("UserName", model.UserName);
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("HomePage", "Heim");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) 
            {
                _service.SaveUserToDB(model);
                model.Message = "User registered successfully";
                return View(model);
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            this.Session.Clear();
            return RedirectToAction("Logon");
        }
    }
}