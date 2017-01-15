using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HsCentralServiceWeb._sys;






namespace HsCentralServiceWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
			lock(Sys.Data)
				return View();
        }
    }
}