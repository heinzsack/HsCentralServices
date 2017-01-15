// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using CsWpfBase.Global.remote.clientIdentification.interfaces;






namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows
{
	partial class RemoteComputer : ICsClientInfoComputer
	{
		#region Overrides/Interfaces
		public double TotalScreenWidth { get; set; }
		public double TotalScreenHeight { get; set; }
		#endregion
	}
}