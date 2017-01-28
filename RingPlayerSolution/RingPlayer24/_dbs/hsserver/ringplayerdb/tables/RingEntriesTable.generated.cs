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
//<date>2017-01-26 17:28:57</date>



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
using RingPlayer24._dbs.hsserver.ringplayerdb.dataset;
using RingEntry=RingPlayer24._dbs.hsserver.ringplayerdb.rows.RingEntry;
using IRingEntry=RingPlayer24._dbs.hsserver.ringplayerdb.rowinterfaces.IRingEntry;
using RingPlayer24._dbs.hsserver;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.tables
{
	#pragma warning disable 657
	#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	
	///	<summary>
	///		'[<c>HsServer</c>].[<c>#RingPlayerDb#</c>].[<c>RingEntries</c>]': A Table inside '[<c>HsServer</c>].[<c>#RingPlayerDb#</c>]' database with '<see cref="RingEntry"/>' as <see cref="DataRow"/>.<para/>
	///		[<c>RingEntries</c>].[<c>PageId</c>] &#62;&#62;&#62;&#62; [<c>Pages</c>].[<c>Id</c>]<para/>
	///		[<c>RingEntries</c>].[<c>RingId</c>] &#62;&#62;&#62;&#62; [<c>Rings</c>].[<c>Id</c>]
	///	</summary>
	[Serializable]
	[DebuggerDisplay("DataTable(RingPlayerDb.RingEntries): Rows[{Rows.Count}]")]
	[CsDbDataTable(Database = "RingPlayerDb", Name = "RingEntries", Generated = "17.01.26 17:28:57", Hash = "A976A6D1E8DE40A51578DCDD83C83DE7")]
	[CsDbResolvesRelation("FK_ScheduledPages_Pages", PkTable = "Pages", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "PageId")]
	[CsDbResolvesRelation("FK_RingEntries_Rings", PkTable = "Rings", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "RingId")]
	public partial class RingEntriesTable : CsDbTable<RingEntry>
	{
		#region CONSTANTS
		///<summary>The native table name (RingEntries).</summary>
		public const string NativeName = "RingEntries";
		///<summary>Holds native column name of <c>[RingPlayerDb].[RingEntries].[Id]</c> column. Property = <see cref="RingEntry.Id"/>.</summary>
		public const string IdCol = "Id";
		///<summary>Holds native column name of <c>[RingPlayerDb].[RingEntries].[PageId]</c> column. Property = <see cref="RingEntry.PageId"/>.</summary>
		public const string PageIdCol = "PageId";
		///<summary>Holds native column name of <c>[RingPlayerDb].[RingEntries].[RingId]</c> column. Property = <see cref="RingEntry.RingId"/>.</summary>
		public const string RingIdCol = "RingId";
		///<summary>Holds native column name of <c>[RingPlayerDb].[RingEntries].[StartTime]</c> column. Property = <see cref="RingEntry.StartTime"/>.</summary>
		public const string StartTimeCol = "StartTime";
		///<summary>Holds native column name of <c>[RingPlayerDb].[RingEntries].[DiagnosticText]</c> column. Property = <see cref="RingEntry.DiagnosticText"/>.</summary>
		public const string DiagnosticTextCol = "DiagnosticText";
	
		/// <summary> Contains attribute values for the columns</summary>
		public static class Cols
		{
			/// <summary>
			///		Get the attribute from the column [<c>RingPlayerDb</c>].[<c>RingEntries</c>].[<c>Id</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RingEntries", Name = "Id", Type = "uniqueidentifier", Default = "(newid())", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Id = new CsDbNativeDataColumnAttribute {Table = "RingEntries", Name = "Id", Type = "uniqueidentifier", Default = "(newid())", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>RingPlayerDb</c>].[<c>RingEntries</c>].[<c>PageId</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RingEntries", Name = "PageId", Type = "uniqueidentifier", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute PageId = new CsDbNativeDataColumnAttribute {Table = "RingEntries", Name = "PageId", Type = "uniqueidentifier", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>RingPlayerDb</c>].[<c>RingEntries</c>].[<c>RingId</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RingEntries", Name = "RingId", Type = "uniqueidentifier", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute RingId = new CsDbNativeDataColumnAttribute {Table = "RingEntries", Name = "RingId", Type = "uniqueidentifier", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>RingPlayerDb</c>].[<c>RingEntries</c>].[<c>StartTime</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RingEntries", Name = "StartTime", Type = "datetime2", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute StartTime = new CsDbNativeDataColumnAttribute {Table = "RingEntries", Name = "StartTime", Type = "datetime2", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>RingPlayerDb</c>].[<c>RingEntries</c>].[<c>DiagnosticText</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RingEntries", Name = "DiagnosticText", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute DiagnosticText = new CsDbNativeDataColumnAttribute {Table = "RingEntries", Name = "DiagnosticText", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES"};
		}
		#endregion
	
	
	
	
	
	
	
		///<summary>Default constructor for save <see cref="DataTable"/> operations</summary>
		public RingEntriesTable()
		{
			TableName = NativeName;
		}
	
		///<summary>References the owning data context, this is equal to the database server. Use this to address databases on the same server.</summary>
		public new RingPlayer24._dbs.hsserver.HsServerContext DataContext => DataSet.DataContext;
	
		///<summary>References the owning dataset. Use this to address tables in the same database</summary>
		public new RingPlayerDb DataSet => (RingPlayerDb) base.DataSet;
	
	
	
	
	
	
	
		#region FUNC<Overrides>
		
		///	<summary><c>SELECT (DefaultSqlSelector) FROM [RingEntries]</c><para>The default selector is the * operator</para></summary>
		[DebuggerStepThrough] 
		public override void DownloadRows()
		{
			DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}]", false);
			HasBeenLoaded = true;
		}
		///	<summary><c>SELECT <paramref name="top"/> (DefaultSqlSelector) FROM [RingEntries]</c><para>The default selector is the * operator</para></summary>
		[DebuggerStepThrough] 
		public override void DownloadRows(int top)
		{
			DownloadRows($"SELECT TOP {top} {DefaultSqlSelector} FROM [{NativeName}]", false);
		}
		
		
		///<summary>This method calls <see cref="FindOrLoad"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase Generic_FindOrLoad(object id)
		{
			return id==null ? null : FindOrLoad((Guid?) id);
		}
		///<summary>This method calls <see cref="LoadThenFind"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase Generic_LoadThenFind(object id)
		{
			return id==null ? null : LoadThenFind((Guid?) id);
		}
		///<summary>This method calls <see cref="Find"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase Generic_Find(object id)
		{
			return id==null ? null : Find((Guid?) id);
		}
		
		
		
		///<summary>This method calls <see cref="FindOrLoad"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase[] Generic_FindOrLoad(params object[] ids)
		{
			return FindOrLoad_Each(ids.OfType<Guid>().ToArray()).OfType<CsDbRowBase>().ToArray();
		}
		///<summary>This method calls <see cref="LoadThenFind"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase[] Generic_LoadThenFind(params object[] ids)
		{
			return LoadThenFind_Each(ids.OfType<Guid>().ToArray()).OfType<CsDbRowBase>().ToArray();
		}
		///<summary>This method calls <see cref="Find"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase[] Generic_Find(params object[] ids)
		{
			return Find_Each(ids.OfType<Guid>().ToArray()).OfType<CsDbRowBase>().ToArray();
		}
		#endregion
		
		
		
		
		#region FUNC<Primary Key>
		
		///	<summary>
		///		find an item in local data where Id = '<paramref name="id"/>'. If nothing is found QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [RingEntries] WHERE [Id] = '<paramref name="id"/>'</c>.<para/>
		///		If no primary key is set execute <see cref="LoadThenFind"/> instead.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		[CsDbResolvesRelation("FK_ScheduledPages_Pages", PkTable = "Pages", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "PageId")]
		[CsDbResolvesRelation("FK_RingEntries_Rings", PkTable = "Rings", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "RingId")]
		[DebuggerStepThrough] 
		public RingEntry FindOrLoad(Guid? id)
		{
			if (id == null)
				return null;
		
			if (PrimaryKey.Length == 0)
				return LoadThenFind(id);
		
			return Find(id) ?? LoadThenFind(id);
		}
		
		
		///<summary>
		///		QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [RingEntries] WHERE [Id] = '<paramref name="id"/>'</c> THEN find an item in local data where Id = '<paramref name="id"/>'.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///</summary>
		[CsDbResolvesRelation("FK_ScheduledPages_Pages", PkTable = "Pages", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "PageId")]
		[CsDbResolvesRelation("FK_RingEntries_Rings", PkTable = "Rings", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "RingId")]
		[DebuggerStepThrough] 
		public RingEntry LoadThenFind(Guid? id)
		{
			if (id == null)
				return null;
		
			DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}] WHERE [Id] = '{id}'", false);
			
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[IdCol] };
		
			return Rows.Find(id.Value) as RingEntry;
		}
		
		
		///	<summary>
		///		find an item in local data where Id = '<paramref name="id"/>'. IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		[CsDbResolvesRelation("FK_ScheduledPages_Pages", PkTable = "Pages", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "PageId")]
		[CsDbResolvesRelation("FK_RingEntries_Rings", PkTable = "Rings", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "RingId")]
		[DebuggerStepThrough] 
		public RingEntry Find(Guid? id)
		{
			if (id == null)
				return null;
		
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[IdCol] };
		
			return Rows.Find(id.Value) as RingEntry;
		}
		#endregion
		
		#region FUNC<Primary Key Many>
		///	<summary>
		///		find items in local data where Id IN '<paramref name="ids"/>'. If nothing is found QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [RingEntries] WHERE [Id] IN '<paramref name="ids"/>'</c>.<para/>
		///		If no primary key is set execute <see cref="LoadThenFind_Each"/> instead.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		[CsDbResolvesRelation("FK_ScheduledPages_Pages", PkTable = "Pages", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "PageId")]
		[CsDbResolvesRelation("FK_RingEntries_Rings", PkTable = "Rings", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "RingId")]
		[DebuggerStepThrough] 
		public RingEntry[] FindOrLoad_Each(params Guid[] ids)
		{
			if (ids == null || ids.Length == 0)
				return new RingEntry[0];
		
			if (PrimaryKey.Length == 0)
				return LoadThenFind_Each(ids);
				
			var locallyFound = Find_Each(ids);
			var loaded = LoadThenFind_Each(ids.Except(locallyFound.Select(x=>x.Id)).ToArray());
			return locallyFound.Union(loaded).ToArray();
		}
		
		
		///<summary>
		///		QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [RingEntries] WHERE [Id] IN '<paramref name="ids"/>'</c> THEN find items in local data where Id IN '<paramref name="ids"/>'.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///</summary>
		[CsDbResolvesRelation("FK_ScheduledPages_Pages", PkTable = "Pages", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "PageId")]
		[CsDbResolvesRelation("FK_RingEntries_Rings", PkTable = "Rings", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "RingId")]
		[DebuggerStepThrough] 
		public RingEntry[] LoadThenFind_Each(params Guid[] ids)
		{
			if (ids == null || ids.Length == 0)
				return new RingEntry[0];
		
			DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}] WHERE [Id] IN ('{ids.Select(x=>x.ToString()).Join("', '")}')", false);
			
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[IdCol] };
		
			return Find_Each(ids);
		}
		
		
		///	<summary>
		///		find items in local data where Id IN '<paramref name="ids"/>'. IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		[CsDbResolvesRelation("FK_ScheduledPages_Pages", PkTable = "Pages", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "PageId")]
		[CsDbResolvesRelation("FK_RingEntries_Rings", PkTable = "Rings", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "RingId")]
		[DebuggerStepThrough] 
		public RingEntry[] Find_Each(params Guid[] ids)
		{
			if (ids == null || ids.Length == 0)
				return new RingEntry[0];
		
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[IdCol] };
				
			return Select(ids.Select(key=>$"{IdCol} = '{key}'").Join(" OR "));
		}
		#endregion
		
		
		
		
		
		#region FUNC<Foreign Key>
		[field:NonSerialized] private Dictionary<Guid?, CsWeakReference<ContractCollection<RingEntry>>> _byPageId = new Dictionary<Guid?, CsWeakReference<ContractCollection<RingEntry>>>();
		
		///	<summary> 
		///		Query <c>SELECT (DefaultSqlSelector) FROM RingEntries WHERE [PageId] = '<paramref name="pageId"/>'</c><para/>
		///		[<c>RingEntries</c>].[<c>PageId</c>] &#62;&#62;&#62;&#62; [<c>Pages</c>].[<c>Id</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_ScheduledPages_Pages", PkTable = "Pages", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "PageId")]
		[DebuggerStepThrough]
		public ContractCollection<RingEntry> FindOrLoad_By_PageId(Guid? pageId)
		{
			if (pageId == null)
				return null;
			CsWeakReference<ContractCollection<RingEntry>> weak;
			ContractCollection<RingEntry> result;
		
			if (_byPageId.TryGetValue(pageId, out weak) && weak.TryGetTarget(out result))
				return result;
		
			if (HasBeenLoaded == true || weak != null)
				result = CreateContractCollection(@ringEntry => Equals(@ringEntry.PageId, pageId));
			else 
			{
				DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}] WHERE [{PageIdCol}] = '{pageId}'", false);
				result = CreateContractCollection(@ringEntry => Equals(@ringEntry.PageId, pageId));
			}
		
			if (weak == null)
				_byPageId.Add(pageId, weak = new CsWeakReference<ContractCollection<RingEntry>>(result));
			else
				weak.SetTarget(result);
		
			return result;
		}
		///	<summary> 
		///		Query <c>SELECT (DefaultSqlSelector) FROM RingEntries WHERE [PageId] = '<paramref name="pageId"/>'</c><para/>
		///		[<c>RingEntries</c>].[<c>PageId</c>] &#62;&#62;&#62;&#62; [<c>Pages</c>].[<c>Id</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_ScheduledPages_Pages", PkTable = "Pages", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "PageId")]
		[DebuggerStepThrough] 
		public ContractCollection<RingEntry> LoadThenFind_By_PageId(Guid? pageId)
		{
			if (pageId == null)
				return null;
			CsWeakReference<ContractCollection<RingEntry>> weak;
			ContractCollection<RingEntry> result;
		
			DownloadRows($"SELECT {DefaultSqlSelector} FROM {NativeName} WHERE [{PageIdCol}] = '{pageId}'", false);
		
			if (_byPageId.TryGetValue(pageId, out weak) && weak.TryGetTarget(out result))
				return result;
		
			result = CreateContractCollection(@ringEntry => Equals(@ringEntry.PageId, pageId));
		
			if (weak == null)
				_byPageId.Add(pageId, weak = new CsWeakReference<ContractCollection<RingEntry>>(result));
			else
				weak.SetTarget(result);
		
			return result;
		}
		///	<summary> 
		///		Query <c>SELECT (DefaultSqlSelector) FROM RingEntries WHERE [PageId] = '<paramref name="pageId"/>'</c><para/>
		///		[<c>RingEntries</c>].[<c>PageId</c>] &#62;&#62;&#62;&#62; [<c>Pages</c>].[<c>Id</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_ScheduledPages_Pages", PkTable = "Pages", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "PageId")]
		[DebuggerStepThrough]
		public ContractCollection<RingEntry> Find_By_PageId(Guid? pageId)
		{
			if (pageId == null)
				return null;
			CsWeakReference<ContractCollection<RingEntry>> weak;
			ContractCollection<RingEntry> result;
		
			if (_byPageId.TryGetValue(pageId, out weak) && weak.TryGetTarget(out result))
				return result;
		
		
			result = CreateContractCollection(@ringEntry => Equals(@ringEntry.PageId, pageId));
		
		    if (weak == null)
				_byPageId.Add(pageId, weak = new CsWeakReference<ContractCollection<RingEntry>>(result));
			else
				weak.SetTarget(result);
		
			return result;
		}
		[field:NonSerialized] private Dictionary<Guid?, CsWeakReference<ContractCollection<RingEntry>>> _byRingId = new Dictionary<Guid?, CsWeakReference<ContractCollection<RingEntry>>>();
		
		///	<summary> 
		///		Query <c>SELECT (DefaultSqlSelector) FROM RingEntries WHERE [RingId] = '<paramref name="ringId"/>'</c><para/>
		///		[<c>RingEntries</c>].[<c>RingId</c>] &#62;&#62;&#62;&#62; [<c>Rings</c>].[<c>Id</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_RingEntries_Rings", PkTable = "Rings", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "RingId")]
		[DebuggerStepThrough]
		public ContractCollection<RingEntry> FindOrLoad_By_RingId(Guid? ringId)
		{
			if (ringId == null)
				return null;
			CsWeakReference<ContractCollection<RingEntry>> weak;
			ContractCollection<RingEntry> result;
		
			if (_byRingId.TryGetValue(ringId, out weak) && weak.TryGetTarget(out result))
				return result;
		
			if (HasBeenLoaded == true || weak != null)
				result = CreateContractCollection(@ringEntry => Equals(@ringEntry.RingId, ringId));
			else 
			{
				DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}] WHERE [{RingIdCol}] = '{ringId}'", false);
				result = CreateContractCollection(@ringEntry => Equals(@ringEntry.RingId, ringId));
			}
		
			if (weak == null)
				_byRingId.Add(ringId, weak = new CsWeakReference<ContractCollection<RingEntry>>(result));
			else
				weak.SetTarget(result);
		
			return result;
		}
		///	<summary> 
		///		Query <c>SELECT (DefaultSqlSelector) FROM RingEntries WHERE [RingId] = '<paramref name="ringId"/>'</c><para/>
		///		[<c>RingEntries</c>].[<c>RingId</c>] &#62;&#62;&#62;&#62; [<c>Rings</c>].[<c>Id</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_RingEntries_Rings", PkTable = "Rings", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "RingId")]
		[DebuggerStepThrough] 
		public ContractCollection<RingEntry> LoadThenFind_By_RingId(Guid? ringId)
		{
			if (ringId == null)
				return null;
			CsWeakReference<ContractCollection<RingEntry>> weak;
			ContractCollection<RingEntry> result;
		
			DownloadRows($"SELECT {DefaultSqlSelector} FROM {NativeName} WHERE [{RingIdCol}] = '{ringId}'", false);
		
			if (_byRingId.TryGetValue(ringId, out weak) && weak.TryGetTarget(out result))
				return result;
		
			result = CreateContractCollection(@ringEntry => Equals(@ringEntry.RingId, ringId));
		
			if (weak == null)
				_byRingId.Add(ringId, weak = new CsWeakReference<ContractCollection<RingEntry>>(result));
			else
				weak.SetTarget(result);
		
			return result;
		}
		///	<summary> 
		///		Query <c>SELECT (DefaultSqlSelector) FROM RingEntries WHERE [RingId] = '<paramref name="ringId"/>'</c><para/>
		///		[<c>RingEntries</c>].[<c>RingId</c>] &#62;&#62;&#62;&#62; [<c>Rings</c>].[<c>Id</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_RingEntries_Rings", PkTable = "Rings", PkColumn = "Id", FkTable = "RingEntries", FkColumn = "RingId")]
		[DebuggerStepThrough]
		public ContractCollection<RingEntry> Find_By_RingId(Guid? ringId)
		{
			if (ringId == null)
				return null;
			CsWeakReference<ContractCollection<RingEntry>> weak;
			ContractCollection<RingEntry> result;
		
			if (_byRingId.TryGetValue(ringId, out weak) && weak.TryGetTarget(out result))
				return result;
		
		
			result = CreateContractCollection(@ringEntry => Equals(@ringEntry.RingId, ringId));
		
		    if (weak == null)
				_byRingId.Add(ringId, weak = new CsWeakReference<ContractCollection<RingEntry>>(result));
			else
				weak.SetTarget(result);
		
			return result;
		}
		#endregion
		
		
		/// <summary>Creates a row then copy's the data from the <paramref name="item"/> and adds it to the row collection.</summary>
		public RingEntry AddAsNewRow(IRingEntry item)
		{
			var row = NewRow();
			row.Copy_From(item, true);
			Add(row);
			return row;
		}
	}
}