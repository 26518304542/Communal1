using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Communal1.Controllers
{
    [Authorize]
    public class HeimController : Controller
    {
        // GET: Heim
        public ActionResult HomePage()
        {
            return View();
        }
    }
}