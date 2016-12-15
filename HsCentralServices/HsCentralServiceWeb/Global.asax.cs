using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CsWpfBase.Ev.Public.Extensions;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWeb._sys;
using HsCentralServiceWeb._sys._extensions;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;


namespace HsCentralServiceWeb
	{
	public class MvcApplication : System.Web.HttpApplication
		{

		public static System.Threading.Timer AutoGenerateTimer;

		protected void Application_Start()
			{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
//TODo by HS removed after checked with CS to fill the database for the first time
			Sys.Data.CentralService.LoadAll_IfHasNotBeenLoaded();
			}

		protected void Application_Error(object sender, EventArgs e)
			{
			Exception exception = Server.GetLastError();
			Server.ClearError();
			Response.Clear();
			Response.StatusCode = exception is HttpException
				? ((HttpException) exception).GetHttpCode()
				: (int) HttpStatusCode.BadRequest;
			Response.Output.Write(exception?.MostInner()?.Message + "\r\n\r\n\r\n" + exception?.MostInner()?.StackTrace);
			}

		//private static void RunAutoGenerate(Object obj)
		//	{
		//	Sys.Services.
		//	double secondsToNextStart = 3600 - DateTime.Now.Second + 330;
		//	//AutoGenerateTimer = new System.Threading.Timer(RunAutoGenerate, new Object(),
		//	//	TimeSpan.FromSeconds(secondsToNextStart), TimeSpan.FromHours(1));
		//	AutoGenerateTimer = new System.Threading.Timer(RunAutoGenerate, new Object(),
		//		TimeSpan.FromSeconds(120), TimeSpan.FromSeconds(120));
		//	lock (Sys.Data)
		//		{
		//		RingMetaData firstRing = null;
		//		RemoteInstance firstRemoteInstance = null;
		//		foreach (RemoteInstance centralServiceRemoteInstance in Sys.Hubs.RingDistribution.ConnectedClients)
		//			{
		//			RemoteInstance remoteInstance = Sys.Data.CentralService.RemoteInstances.FindOrLoad(centralServiceRemoteInstance.Id);
		//			remoteInstance.ThrowNotFound_If_Null(
		//				$"Es exestiert keine remoteInstance mit der ID = '{centralServiceRemoteInstance.Id}'");
		//			RingMetaData ring = Sys.Services.RingDistribution.Generate.For(remoteInstance);
		//			if (firstRing == null)
		//				{
		//				firstRing = ring;
		//				firstRemoteInstance = remoteInstance;
		//				}
		//			}
		//		}
		//	}
		}
	}
