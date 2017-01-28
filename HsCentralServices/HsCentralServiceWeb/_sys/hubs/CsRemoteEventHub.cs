// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-26</date>

using System;
using System.Threading.Tasks;
using CsWpfBase.Global.remote;
using CsWpfBase.Global.remote.services.eventHub;
using CsWpfBase.Global.remote.services.eventHub.components;
using JetBrains.Annotations;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;






namespace HsCentralServiceWeb._sys.hubs
{
	[UsedImplicitly]
	[HubName(CsRemoteProtocol.ServiceRoutes.EventHubName)]
	public class CsRemoteEventHub : Hub
	{
		#region Overrides/Interfaces
		public override Task OnConnected()
		{
			EventHubServer.I.OnConnected(this);
			Sys.Hubs.WwwSurferNotification.ConnectedClientsChanged();
			return base.OnConnected();
		}

		public override Task OnReconnected()
		{
			EventHubServer.I.OnConnected(this);
			Sys.Hubs.WwwSurferNotification.ConnectedClientsChanged();
			return base.OnReconnected();
		}

		public override Task OnDisconnected(bool stopCalled)
		{
			EventHubServer.I.OnDisconnected(this, stopCalled);
			Sys.Hubs.WwwSurferNotification.ConnectedClientsChanged();
			return base.OnDisconnected(stopCalled);
		}
		#endregion


		[UsedImplicitly]
		[HubMethodName(EventHubServer.Methods.SubscribeEvent)]
		public void SubscribeEvent(string eventName)
		{
			EventHubServer.I.OnSubscribeEvent(this, eventName);
			Sys.Hubs.WwwSurferNotification.ConnectedClientsChanged();
		}

		[UsedImplicitly]
		[HubMethodName(EventHubServer.Methods.UnsubscribeEvent)]
		public void UnsubscribeEvent(string eventName)
		{
			EventHubServer.I.OnUnsubscribeEvent(this, eventName);
			Sys.Hubs.WwwSurferNotification.ConnectedClientsChanged();
		}

		[UsedImplicitly]
		[HubMethodName(EventHubServer.Methods.RaiseEvent)]
		public void RaiseEvent(string eventName, string data, bool includeSelf, string[] includedClients, string[] excludedClients)
		{
			EventHubServer.I.OnRaiseEvent(this, eventName, data, includeSelf, includedClients, excludedClients);
		}

		[UsedImplicitly]
		[HubMethodName(EventHubServer.Methods.GetListeners)]
		public EventHubListener[] GetListeners()
		{
			return EventHubServer.I.OnGetListeners();
		}
	}
}