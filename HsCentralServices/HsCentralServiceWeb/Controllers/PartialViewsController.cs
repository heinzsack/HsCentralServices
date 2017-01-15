// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-15</date>

using System;
using System.Web.Mvc;
using HsCentralServiceWeb._sys;






namespace HsCentralServiceWeb.Controllers
{
	public class PartialViewsController : Controller
	{
		// GET: PartialViews
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Partial_ConnectedClients()
		{
			lock(Sys.Data)
				return PartialView("controls/List_ConnectedClients");
		}

		public ActionResult Partial_LogsList()
		{
			lock(Sys.Data)
				return PartialView("controls/List_RemoteLogs");
		}
	}
}