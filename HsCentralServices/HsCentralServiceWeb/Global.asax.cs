using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CsWpfBase.Ev.Public.Extensions;






namespace HsCentralServiceWeb
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

		protected void Application_Error(object sender, EventArgs e)
		{
			Exception exception = Server.GetLastError();
			Server.ClearError();
			Response.Clear();
			Response.StatusCode = exception is HttpException
				? ((HttpException)exception).GetHttpCode()
				: (int)HttpStatusCode.BadRequest;
			Response.Output.Write(exception?.MostInner()?.Message + "\r\n\r\n\r\n" + exception?.MostInner()?.StackTrace);
		}
	}
	}
