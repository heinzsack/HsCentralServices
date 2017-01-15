// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.Windows.Markup;
using CsWpfBase.Global.remote.clientIdentification.interfaces;






namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows
{
	partial class RemoteInstance : ICsClientInfoAppInstance
	{
		#region Overrides/Interfaces
		[DependsOn(nameof(TicksUseageTime))]
		public TimeSpan? UseageTime
		{
			get { return TicksUseageTime == null ? null : (TimeSpan?) TimeSpan.FromTicks(TicksUseageTime.Value); }
			set { TicksUseageTime = value?.Ticks; }
		}
		#endregion
	}
}