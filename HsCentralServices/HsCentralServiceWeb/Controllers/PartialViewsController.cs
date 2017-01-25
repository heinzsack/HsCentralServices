// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-22</date>

using System;
using System.Web.Mvc;






namespace HsCentralServiceWeb.Controllers
{
	public class PartialViewsController : Controller
	{
		public ActionResult Partial_ConnectedClients()
		{
			return PartialView("controls/List_ConnectedClients");
		}

		public ActionResult Partial_LogsList()
		{
			return PartialView("controls/List_RemoteLogs");
		}
	}
}