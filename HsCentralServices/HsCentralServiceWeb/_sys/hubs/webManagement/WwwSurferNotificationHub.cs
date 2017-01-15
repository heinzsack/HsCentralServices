// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Mvc;
using CsWpfBase.Ev.Public.Extensions;
using JetBrains.Annotations;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;






namespace HsCentralServiceWeb._sys.hubs.webManagement
{
	[HubName(nameof(WwwSurferNotificationHub))]
	public class WwwSurferNotificationHub : Hub
	{
		public static HubConnectionHandler<string> ConnectionHandler { get; } = new HubConnectionHandler<string>(GlobalHost.ConnectionManager.GetHubContext<WwwSurferNotificationHub>(), GetIdentification);

		public static MvcHtmlString Attach_RemoteLogsChanged(string formId)
		{
			return EnterNotificationsScript(formId, nameof(WwwSurferNotificationHubModule.LogsChanged));
		}

		public static MvcHtmlString Attach_ConnectedClientsChanged(string formId)
		{
			return EnterNotificationsScript(formId, nameof(WwwSurferNotificationHubModule.ConnectedClientsChanged));
		}


		public static void SendSignal(Guid[] ids = null, [CallerMemberName] string signal = null)
		{
			var hubContext = GlobalHost.ConnectionManager.GetHubContext<WwwSurferNotificationHub>();
			hubContext.Clients.Group(signal).Invoke(signal);


			if (ids == null)
				return;
			foreach (var id in ids)
			{
				hubContext.Clients.Group($"{signal}:{id}").Invoke(signal);
			}
		}



		private static string GetIdentification(HubCallerContext hubCallerContext)
		{
			return hubCallerContext.ConnectionId;
		}

		private static MvcHtmlString EnterNotificationsScript(string formid, string signal, Guid[] ids = null)
		{
			var builder = new TagBuilder("script");
			builder.Attributes.Add("type", "text/javascript");
			builder.InnerHtml = ids != null ? $"EnterNotification($('#{formid}'), '{signal}', '{ids.Select(x => x.ToString()).Join()}');" : $"EnterNotification($('#{formid}'), '{signal}', '');";
			return new MvcHtmlString(builder.ToString());
		}


		#region Overrides/Interfaces
		public override Task OnConnected()
		{
			ConnectionHandler.Connected(Context);
			return base.OnConnected();
		}

		public override Task OnReconnected()
		{
			ConnectionHandler.Reconnected(Context);
			return base.OnReconnected();
		}

		public override Task OnDisconnected(bool stopCalled)
		{
			ConnectionHandler.Disconnected(Context);
			return base.OnDisconnected(stopCalled);
		}
		#endregion


		[UsedImplicitly]
		public void JoinSignal(string signal, string mergedIds)
		{
			if (string.IsNullOrEmpty(mergedIds))
			{
				Groups.Add(Context.ConnectionId, $"{signal}");
				return;
			}
			var ids = mergedIds.Split(", ");
			foreach (var id in ids)
			{
				Groups.Add(Context.ConnectionId, $"{signal}:{id}");
			}
		}
	}
}