//********************************************************************
//
//                 AUTOGENERATED CONTENT DO NOT MODIFY
//                      PRODUCED BY CsWpfBase.Db
//
//********************************************************************
//
//
//Copyright (c) 2014 - 2016 All rights reserved Christian Sack
//<author>Christian Sack</author>
//<email>service.christian@sack.at</email>
//<website>christian.sack.at</website>
//<date>2017-02-05 16:40:03</date>



using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Markup;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Db.attributes;
using CsWpfBase.Db.attributes.columnAttributes;
using CsWpfBase.Db.models;
using CsWpfBase.Db.models.helper;
using CsWpfBase.Db.models.bases;
using CsWpfBase.Db.router;
using System.IO;
using System.Text;
using System.ComponentModel;
using TestApplication._dbs.hsserver.centralservicedb.dataset;






namespace TestApplication._dbs.hsserver
{
	/// <summary>'[<c>HsServer</c>]': a database context providing all databases accessible for a defined user on the server.</summary>
	[Serializable] [DebuggerStepThrough]
	[DebuggerDisplay("DBContext[HsServer]")]
	[CsDbDataContext(Name = "HsServer", Generated = "17.02.05 16:40:03", Hash = "0067E0C0A241835E2111AD738E4CBBCB")]
	public partial class HsServerContext : CsDbDataContext
	{
		/// <summary>Gets the native database server name of the context (HsServer).</summary>
		public const string NativeName = "HsServer";
		/// <summary>Gets the native database server name of the context (HsServer).</summary>
		public override string Name => NativeName;
	
	
	
	#region Databases
		
		private CentralServiceDb _centralServiceDb;
	
	
		///<summary>References the '[HsServer].[CentralServiceDb]' database.</summary>
		public CentralServiceDb CentralServiceDb => GetSet(ref _centralServiceDb);
	
	#endregion
	
	
	
	
		/// <summary>Sets all db proxy's inside this context.</summary>
		public override void Set_DbProxy<T>()
		{
			CentralServiceDb.Set_DbProxy<T>();
		}
		/// <summary>Loads the constraints on each data set within this context.</summary>
		public override void LoadConstraints()
		{
			CentralServiceDb.LoadConstraints();
		}
		///<summary>Get a database/dataset by its native name</summary>
		public override CsDbDataSet GetDatabaseByName(string name)
		{
			switch (name)
			{
				case CentralServiceDb.NativeName:
					return CentralServiceDb;
				default:
					throw new Exception("unknown data set");
			}
		}
	}
}