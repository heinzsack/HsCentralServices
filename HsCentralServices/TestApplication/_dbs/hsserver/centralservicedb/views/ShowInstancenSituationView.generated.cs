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
//<date>2017-01-26 17:28:58</date>



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
using ShowInstancenSituation=TestApplication._dbs.hsserver.centralservicedb.rows.ShowInstancenSituation;






namespace TestApplication._dbs.hsserver.centralservicedb.views
{
	///	<summary> '[<c>HsServer</c>].[<c>#CentralServiceDb#</c>].[<c>ShowInstancenSituation</c>]': A VIEW inside '[<c>HsServer</c>].[<c>#CentralServiceDb#</c>]' database with '<see cref="ShowInstancenSituation"/>' as <see cref="DataRow"/>. </summary>
	[Serializable] [DebuggerStepThrough]
	[DebuggerDisplay("DataVIEW(CentralServiceDb.ShowInstancenSituation): Rows[{Rows.Count}]")]
	[CsDbDataView(Database = "CentralServiceDb", Generated = "17.01.26 17:28:58", Hash = "7DC4E725C877F29867F6B1F00A70CA63")]
	public partial class ShowInstancenSituationView : CsDbView<ShowInstancenSituation>
	{
	
		///<summary>References the owning data context, this is equal to the database server. Use this to address databases on the same server.</summary>
		public new TestApplication._dbs.hsserver.HsServerContext DataContext => DataSet.DataContext;
	
		///<summary>References the owning dataset. Use this to address tables in the same database</summary>
		public new CentralServiceDb DataSet => (CentralServiceDb) base.DataSet;
	
	
		///<summary>Default constructor for save <see cref="DataTable"/> operations</summary>
		public ShowInstancenSituationView()
		{
			TableName = NativeName;
		}
	
	
		#region Column - Constants
		// Column constants are used to help write select statements
		// This can help to prevent runtime exceptions if database have changed
		/// <summary>Gets the native data base view name '<c>ShowInstancenSituation</c>'</summary>
		public const string NativeName = "ShowInstancenSituation";
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>RemoteInstanceId</c>] column. Property = <see cref="ShowInstancenSituation.RemoteInstanceId"/>.</summary>
		public const string RemoteInstanceIdCol = "RemoteInstanceId";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>ProcessFile</c>] column. Property = <see cref="ShowInstancenSituation.ProcessFile"/>.</summary>
		public const string ProcessFileCol = "ProcessFile";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>FirstExecutionTime</c>] column. Property = <see cref="ShowInstancenSituation.FirstExecutionTime"/>.</summary>
		public const string FirstExecutionTimeCol = "FirstExecutionTime";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>LastExecutionTime</c>] column. Property = <see cref="ShowInstancenSituation.LastExecutionTime"/>.</summary>
		public const string LastExecutionTimeCol = "LastExecutionTime";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>Unsigned_StartupCount</c>] column. Property = <see cref="ShowInstancenSituation.UnsignedStartupCount"/>.</summary>
		public const string UnsignedStartupCountCol = "Unsigned_StartupCount";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>Ticks_UseageTime</c>] column. Property = <see cref="ShowInstancenSituation.TicksUseageTime"/>.</summary>
		public const string TicksUseageTimeCol = "Ticks_UseageTime";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>Version</c>] column. Property = <see cref="ShowInstancenSituation.Version"/>.</summary>
		public const string VersionCol = "Version";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>Created</c>] column. Property = <see cref="ShowInstancenSituation.Created"/>.</summary>
		public const string CreatedCol = "Created";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>LastSeen</c>] column. Property = <see cref="ShowInstancenSituation.LastSeen"/>.</summary>
		public const string LastSeenCol = "LastSeen";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>RemoteUserId</c>] column. Property = <see cref="ShowInstancenSituation.RemoteUserId"/>.</summary>
		public const string RemoteUserIdCol = "RemoteUserId";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>RemoteApplicationId</c>] column. Property = <see cref="ShowInstancenSituation.RemoteApplicationId"/>.</summary>
		public const string RemoteApplicationIdCol = "RemoteApplicationId";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>RemoteApplicxationId</c>] column. Property = <see cref="ShowInstancenSituation.RemoteApplicxationId"/>.</summary>
		public const string RemoteApplicxationIdCol = "RemoteApplicxationId";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>Product</c>] column. Property = <see cref="ShowInstancenSituation.Product"/>.</summary>
		public const string ProductCol = "Product";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>ProductTitle</c>] column. Property = <see cref="ShowInstancenSituation.ProductTitle"/>.</summary>
		public const string ProductTitleCol = "ProductTitle";
	
		///<summary>Holds native column name of [<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>].[<c>RemteApplicationName</c>] column. Property = <see cref="ShowInstancenSituation.RemteApplicationName"/>.</summary>
		public const string RemteApplicationNameCol = "RemteApplicationName";
		#endregion
	
	
	
		#region OVERRIDES
		///<summary>Downloads all rows from the ShowInstancenSituation table. See: <c>SELECT * FROM [ShowInstancenSituation]</c></summary>
		public override void DownloadRows()
		{
			DownloadRows($"SELECT * FROM [{NativeName}]", false);
		}
		///	<summary><c>SELECT <paramref name="top"/> * FROM [ShowInstancenSituation]</c></summary>
		public override void DownloadRows(int top)
		{
			DownloadRows($"SELECT TOP {top} * FROM [{NativeName}]", false);
		}
		#endregion
	}
}