using System;
using System.Windows.Markup;
using CsWpfBase.Global.remote.clientIdentification.interfaces;






namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows
{
	partial class RemoteInstance : ICsClientInfoAppInstance
	{
		[DependsOn(nameof(TicksUseageTime))]
		public TimeSpan? UseageTime
		{
			get { return TicksUseageTime==null?null:(TimeSpan?)TimeSpan.FromTicks(TicksUseageTime.Value); }
			set { TicksUseageTime = value?.Ticks; }
		}

		public RemoteRingPlayerManagement RingPlayerManagement
		{
			get
			{
				if (RemoteRingPlayerManagements.Count != 0)
					return RemoteRingPlayerManagements[0];
				RemoteRingPlayerManagement arg = DataSet.RemoteRingPlayerManagements.NewRow();
				arg.Id = Id;
				arg.RemoteInstance = this;
				arg.LastUpdated = DateTime.Now;
				arg.AddToTable();
				return arg;
			}
		}
	}



}