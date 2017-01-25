// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CsWpfBase.Ev.Public.Extensions;






namespace HsCentralServiceWeb
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		protected void Application_Error(object sender, EventArgs e)
		{
			var exception = Server.GetLastError();
			Server.ClearError();
			if (!Response.IsClientConnected)
				return;
			Response.Clear();
			Response.StatusCode = exception is HttpException
				? ((HttpException) exception).GetHttpCode()
				: (int) HttpStatusCode.BadRequest;
			Response.Output.Write(exception?.MostInner()?.Message + "\r\n\r\n\r\n" + exception?.MostInner()?.StackTrace);
		}

	}
}