// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-21</date>

using System;
using System.Collections.ObjectModel;
using System.Windows;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global;
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
			CsGlobal.Remote.EventHub.Connect();
			CsGlobal.Remote.EventHub.AfterConnectionEstablished += EventHub_AfterConnectionEstablished;




			InitializeComponent();
		}

		public ObservableCollection<MessagePacket> Messages { get; } = new ObservableCollection<MessagePacket>();




		private void EventHub_AfterConnectionEstablished()
		{
			CsGlobal.Remote.EventHub.Handle<MessagePacket>("MessageEvent", MessageReceived);
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