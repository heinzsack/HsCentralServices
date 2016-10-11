using System;
using System.Web.Mvc;






namespace HsCentralServiceWeb.Controllers
{
    public class RemoteManagementController : Controller
    {
        // GET: RemoteManagement
        public ActionResult Partial_LogsList()
        {
            return PartialView("controls/List_RemoteLogs");
        }
    }
}