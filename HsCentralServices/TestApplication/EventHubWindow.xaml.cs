// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-21</date>

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global;
using CsWpfBase.Global.remote.services.eventHub;
using CsWpfBase.Global.remote.services.eventHub.components;
using CsWpfBase.Themes.Controls.Containers;






namespace TestApplication
{
	/// <summary>Interaction logic for MessengerWindow.xaml</summary>
	public partial class EventHubWindow : CsWindow
	{
		public EventHubWindow()
		{
			CsGlobal.Install(GlobalFunctions.Storage);
			CsGlobal.InstallRemote("http://localhost:16412/", "<RSAKeyValue><Modulus>7bTXJULjf3ELHOv/57LyGUTBpgQ7CucbdSXusgy+270FPbK0Iboqkqrhs4rbeKkH6AWA6BwXGqUqAwwVNKHPEtXTpLe9GKM41eZOJyhU7QCw0X8BAQXLbTQbc+QGFn/J/t6wlh7cgrYgqe/3Q9u7yW9+j16Q8Uj4OG4N20fsqX0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");


			CsGlobal.Remote.EventHub.TrySubscribe<MessagePacket>("MessageEvent", MessageReceived);
			CsGlobal.Remote.EventHub.RemoteClients.Connected += EventHubOnRemoteClientConnected;
			CsGlobal.Remote.EventHub.RemoteClients.Disconnected += EventHubOnRemoteClientDisconnected;
			CsGlobal.Remote.EventHub.RemoteClients.EventSubscribed += EventHubOnRemoteClientEventSubscribed;
			CsGlobal.Remote.EventHub.RemoteClients.EventUnsubscribed += EventHubOnRemoteClientEventUnsubscribed;


			CsGlobal.Remote.EventHub.Connect();
			this.Closing += OnClosing;



			InitializeComponent();
		}

		private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
		{
			CsGlobal.Remote.EventHub.RemoteClients.Connected -= EventHubOnRemoteClientConnected;
			CsGlobal.Remote.EventHub.RemoteClients.Disconnected -= EventHubOnRemoteClientDisconnected;
			CsGlobal.Remote.EventHub.RemoteClients.EventSubscribed -= EventHubOnRemoteClientEventSubscribed;
			CsGlobal.Remote.EventHub.RemoteClients.EventUnsubscribed -= EventHubOnRemoteClientEventUnsubscribed;
			CsGlobal.Remote.EventHub.Disconnect();
		}

		public ObservableCollection<MessagePacket> Messages { get; } = new ObservableCollection<MessagePacket>();




		private void EventHubOnRemoteClientConnected(EventHubListener listener)
		{
			("REMOTE CONNECTED " + listener.ClientData).WriteToDebug();
		}
		private void EventHubOnRemoteClientEventSubscribed(RemoteClientEventChangedArgs args)
		{
			($"EVENT SUBSCRIBED {args.Listener.ClientData} {args.EventName}").WriteToDebug();
		}
		private void EventHubOnRemoteClientEventUnsubscribed(RemoteClientEventChangedArgs args)
		{
			($"EVENT UNSUBSCRIBED {args.Listener.ClientData} {args.EventName}").WriteToDebug();
		}
		private void EventHubOnRemoteClientDisconnected(EventHubListener listener)
		{
			("REMOTE DISCONNECTED " + listener.ClientData).WriteToDebug();
		}

		private void MessageReceived(MessagePacket eventData)
		{
			Messages.Insert(0, eventData);
		}

		private void SendButton_Clicked(object sender, RoutedEventArgs e)
		{
			var packet = new MessagePacket
			{
				Sender = SenderEditor.Value.IsNullOrEmpty() ? CsGlobal.Os.Info.ComputerName : SenderEditor.Value,
				Message = MessageEditor.Value
			};
			CsGlobal.Remote.EventHub.Raise("MessageEvent", packet, true);
		}
	}



	public class MessagePacket
	{
		public string Sender { get; set; }
		public string Message { get; set; }
	}
}