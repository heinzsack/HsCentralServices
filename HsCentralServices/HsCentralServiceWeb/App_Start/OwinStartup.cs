using System;
using HsCentralServiceWeb;
using Microsoft.Owin;
using Owin;






[assembly: OwinStartup(typeof(OwinStartup))]
namespace HsCentralServiceWeb
{
	public class OwinStartup
	{
		public void Configuration(IAppBuilder app)
		{
			app.MapSignalR();
		}
	}
}