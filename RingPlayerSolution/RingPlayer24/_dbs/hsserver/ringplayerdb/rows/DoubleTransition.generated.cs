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
//<date>2017-02-05 16:40:02</date>



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
using RingPlayer24._dbs.hsserver.ringplayerdb.tables;
using RingPlayer24._dbs.hsserver.ringplayerdb.rowinterfaces;
using RingPlayer24._dbs.hsserver.ringplayerdb.rowpocos;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rows
{
	#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	
	///<summary>DataRow([<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>]): row model of <see cref="DoubleTransitionsTable"/>.</summary>
	[Serializable]
	[DebuggerDisplay("DataRow(RingPlayerDb.DoubleTransitions): Id = '{Id}'")]
	[CsDbDataRow(Database = "RingPlayerDb", TableName = "DoubleTransitions", Generated = "17.02.05 16:40:02", Hash = "4F25F71733E3D1F683001592BEFBD75F")]
	public partial class DoubleTransition : CsDbTableRow, IDoubleTransition
	{
		#region statics
		private static Dictionary<string, System.Reflection.PropertyInfo> _nativeColumnName_To_Property;
		public static Dictionary<string, System.Reflection.PropertyInfo> NativeColumnName_To_Property
		{
			get
			{
				if (_nativeColumnName_To_Property != null)
					return _nativeColumnName_To_Property;
		
				var type = typeof(IDoubleTransition);
				_nativeColumnName_To_Property = new Dictionary<string, System.Reflection.PropertyInfo>
				{
					{ DoubleTransitionsTable.IdCol, type.GetProperty(nameof(Id)) },
					{ DoubleTransitionsTable.PageIdCol, type.GetProperty(nameof(PageId)) },
					{ DoubleTransitionsTable.BeginnTimeSecondsCol, type.GetProperty(nameof(BeginnTimeSeconds)) },
					{ DoubleTransitionsTable.DurationSecondsCol, type.GetProperty(nameof(DurationSeconds)) },
					{ DoubleTransitionsTable.FromValueCol, type.GetProperty(nameof(FromValue)) },
					{ DoubleTransitionsTable.ToValueCol, type.GetProperty(nameof(ToValue)) },
					{ DoubleTransitionsTable.PropertyPathCol, type.GetProperty(nameof(PropertyPath)) },
					{ DoubleTransitionsTable.TransitionTypeCol, type.GetProperty(nameof(TransitionType)) },
					{ DoubleTransitionsTable.DiagnosticTextCol, type.GetProperty(nameof(DiagnosticText)) }
				};
		
				return _nativeColumnName_To_Property;
			}
		}
		#endregion
	
	
		public DoubleTransition(DataRowBuilder builder) : base(builder){}
	
		
		///<summary>References the owning data context, this is equal to the database server. Use this to address databases on the same server.</summary>
		public new RingPlayer24._dbs.hsserver.HsServerContext DataContext => Table.DataContext;
	
		///<summary>References the owning dataset. Use this to address tables in the same database</summary>
		public new RingPlayerDb DataSet => Table.DataSet;
	
		///	<summary>Gets the owning table of type <see cref="DoubleTransitionsTable"/>.</summary>
		public new DoubleTransitionsTable Table => (DoubleTransitionsTable) base.Table;
	
	
	
	
		#region COLUMNS
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>Id</c>] (Type = <c>uniqueidentifier</c>, Default = '<c>(newid())</c>')
		///</summary>
		[CsDbDataColumn(Default = "Guid.NewGuid()")]
		[CsDbNativeDataColumn(Table = "DoubleTransitions", Name = "Id", Type = "uniqueidentifier", Default = "(newid())", IsNullable = "NO")]
		public Guid Id
		{
			[DebuggerStepThrough] get { return GetDbValue<Guid>(DoubleTransitionsTable.IdCol); }
			[DebuggerStepThrough] set { SetDbValue(value, DoubleTransitionsTable.IdCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>PageId</c>] (Type = <c>uniqueidentifier</c>)
		///</summary>
		[CsDbDataColumn]
		[CsDbNativeDataColumn(Table = "DoubleTransitions", Name = "PageId", Type = "uniqueidentifier", IsNullable = "NO")]
		public Guid PageId
		{
			[DebuggerStepThrough] get { return GetDbValue<Guid>(DoubleTransitionsTable.PageIdCol); }
			[DebuggerStepThrough] set { SetDbValue(value, DoubleTransitionsTable.PageIdCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>BeginnTimeSeconds</c>] (Type = <c>float</c>)
		///</summary>
		[CsDbDataColumn]
		[CsDbNativeDataColumn(Table = "DoubleTransitions", Name = "BeginnTimeSeconds", Type = "float", IsNullable = "NO")]
		public Double BeginnTimeSeconds
		{
			[DebuggerStepThrough] get { return GetDbValue<Double>(DoubleTransitionsTable.BeginnTimeSecondsCol); }
			[DebuggerStepThrough] set { SetDbValue(value, DoubleTransitionsTable.BeginnTimeSecondsCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>DurationSeconds</c>] (Type = <c>float</c>)
		///</summary>
		[CsDbDataColumn]
		[CsDbNativeDataColumn(Table = "DoubleTransitions", Name = "DurationSeconds", Type = "float", IsNullable = "NO")]
		public Double DurationSeconds
		{
			[DebuggerStepThrough] get { return GetDbValue<Double>(DoubleTransitionsTable.DurationSecondsCol); }
			[DebuggerStepThrough] set { SetDbValue(value, DoubleTransitionsTable.DurationSecondsCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>FromValue</c>] (Type = <c>float</c>)
		///</summary>
		[CsDbDataColumn]
		[CsDbNativeDataColumn(Table = "DoubleTransitions", Name = "FromValue", Type = "float", IsNullable = "NO")]
		public Double FromValue
		{
			[DebuggerStepThrough] get { return GetDbValue<Double>(DoubleTransitionsTable.FromValueCol); }
			[DebuggerStepThrough] set { SetDbValue(value, DoubleTransitionsTable.FromValueCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>ToValue</c>] (Type = <c>float</c>)
		///</summary>
		[CsDbDataColumn]
		[CsDbNativeDataColumn(Table = "DoubleTransitions", Name = "ToValue", Type = "float", IsNullable = "NO")]
		public Double ToValue
		{
			[DebuggerStepThrough] get { return GetDbValue<Double>(DoubleTransitionsTable.ToValueCol); }
			[DebuggerStepThrough] set { SetDbValue(value, DoubleTransitionsTable.ToValueCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>PropertyPath</c>] (Type = <c>nvarchar</c>, MaxLength = <c>-1</c>)
		///</summary>
		[CsDbDataColumn]
		[CsDbNativeDataColumn(Table = "DoubleTransitions", Name = "PropertyPath", Type = "nvarchar", MaxLength = "-1", IsNullable = "NO")]
		public String PropertyPath
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(DoubleTransitionsTable.PropertyPathCol); }
			[DebuggerStepThrough] set { SetDbValue(value, DoubleTransitionsTable.PropertyPathCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>TransitionType</c>] (Type = <c>nvarchar</c>, Default = '<c>(N'Cubic')</c>', MaxLength = <c>-1</c>)
		///</summary>
		[CsDbDataColumn(Default = "Cubic")]
		[CsDbNativeDataColumn(Table = "DoubleTransitions", Name = "TransitionType", Type = "nvarchar", Default = "(N'Cubic')", MaxLength = "-1", IsNullable = "NO")]
		public String TransitionType
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(DoubleTransitionsTable.TransitionTypeCol); }
			[DebuggerStepThrough] set { SetDbValue(value, DoubleTransitionsTable.TransitionTypeCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>DiagnosticText</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>)
		///</summary>
		[CsDbDataColumn(IsNullable = true)]
		[CsDbNativeDataColumn(Table = "DoubleTransitions", Name = "DiagnosticText", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES")]
		public String DiagnosticText
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(DoubleTransitionsTable.DiagnosticTextCol); }
			[DebuggerStepThrough] set { SetDbValue(value, DoubleTransitionsTable.DiagnosticTextCol); }
		}
		
		#endregion
	
	
	
	
	
		///	<summary>Reloads the <see cref="DoubleTransition"/> row by executing following command:<para/><c>$"SELECT * FROM DoubleTransitions WHERE [Id] = '<see cref="Id"/>'</c></summary>
		public DoubleTransition Reload()
		{
			Table.DataSet.DoubleTransitions.LoadThenFind(Id);
			return this;
		}
		
		
		
		
		#region PROPERTIES<Many to One>
		private Page _page;
		public bool IsPageLoaded => (_page == null || _page.RowState != DataRowState.Detached) && Equals(_page?.Id, PageId);
		
		///	<summary>
		///		This field has cached Output.<para/>
		///		<c>SELECT * FROM Pages WHERE [Id] = '<paramref name="PageId"/>'</c><para/>[<c>DoubleTransitions</c>].[<c>PageId</c>] &#62;&#62;&#62;&#62; [<c>Pages</c>].[<c>Id</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_DoubleTransitions_Visuals", PkTable = "Pages", PkColumn = "Id", FkTable = "DoubleTransitions", FkColumn = "PageId")][DependsOn("PageId")]
		public Page Page
		{
			[DebuggerStepThrough]
			get 
			{
				if (IsPageLoaded)
					return _page;
				
				_page = Table.DataSet.Pages.FindOrLoad(PageId);
				return _page;
			}
			[DebuggerStepThrough]
			set 
			{
				if (value == null) throw new InvalidOperationException("The value cannot be null (FK: FK_DoubleTransitions_Visuals)");
				if (value != null && value.Table.DataSet != Table.DataSet) throw new InvalidOperationException("The owning data set have to be equal.");
				if (value == _page) return;
		
				_page = value;
		
				if (value == null)
					SetDbValue(default(Guid), DoubleTransitionsTable.PageIdCol, "PageId");
				else
					SetDbValue(value.Id, DoubleTransitionsTable.PageIdCol, "PageId");
			}
		}
		#endregion
		
		
		
		
		
		#region PROPERTIES<One to Many>
		
		#endregion
		
		
		
		
		
		#region FUNC<Overrides>
		protected void Invalidate()
		{
			if (!IsPropertyChangedHandled)
				return;
		
			OnPropertyChanged("Id");
			OnPropertyChanged("PageId");
			OnPropertyChanged("BeginnTimeSeconds");
			OnPropertyChanged("DurationSeconds");
			OnPropertyChanged("FromValue");
			OnPropertyChanged("ToValue");
			OnPropertyChanged("PropertyPath");
			OnPropertyChanged("TransitionType");
			OnPropertyChanged("DiagnosticText");
		}
		///	<summary> Set all values which have default values inside the database to their defaults. This method is automatically invoked if you call <see cref="DoubleTransitionsTable.NewRow"/>. </summary>
		public override void ApplyDefaults()
		{
			Id = Guid.NewGuid();
				TransitionType = "Cubic";
		}
		/// <summary>
		///     Loads the complete data bundle of the current row into a target data set.
		///     <para>A data bundle is defined as a set of all rows inside a database which are connected via relations.</para>
		///     <para>The currently selected row is the root of the bundle</para>
		/// </summary>
		public void Copy_BundledData_Into_DataSet(RingPlayerDb target)
		{
			base.Copy_BundledData_Into_DataSet(target);
		}
		
		
		/// <summary>
		///     Loads the complete data bundle of the current row into a new data set.
		///     <para>A data bundle is defined as a set of rows inside a database which are connected via relations.</para>
		///     <para>The currently selected row is the root of the bundle</para>
		/// </summary>
		public new RingPlayerDb Copy_BundledData_In_New_DataSet(bool cloneCompleteSchema = false)
		{
			return (RingPlayerDb) base.Copy_BundledData_In_New_DataSet(cloneCompleteSchema);
		}
		
		#endregion
		
		
		///	<summary> This method copy's each database field into the <paramref name="target"/> interface. </summary>
		public void Copy_To(IDoubleTransition target, bool includePrimaryKey = false)
		{
			if (includePrimaryKey) target.Id = this.Id;
			target.PageId = this.PageId;
			target.BeginnTimeSeconds = this.BeginnTimeSeconds;
			target.DurationSeconds = this.DurationSeconds;
			target.FromValue = this.FromValue;
			target.ToValue = this.ToValue;
			target.PropertyPath = this.PropertyPath;
			target.TransitionType = this.TransitionType;
			target.DiagnosticText = this.DiagnosticText;
		}
		///	<summary> This method copy's each database field from the <paramref name="source"/> interface to this data row.</summary>
		public void Copy_From(IDoubleTransition source, bool includePrimaryKey = false)
		{
			if (includePrimaryKey) this.Id = source.Id;
			this.PageId = source.PageId;
			this.BeginnTimeSeconds = source.BeginnTimeSeconds;
			this.DurationSeconds = source.DurationSeconds;
			this.FromValue = source.FromValue;
			this.ToValue = source.ToValue;
			this.PropertyPath = source.PropertyPath;
			this.TransitionType = source.TransitionType;
			this.DiagnosticText = source.DiagnosticText;
		}
		///	<summary> 
		///		This method copy's each database field which is not in the <paramref name="excludedColumns"/> 
		///		from the <paramref name="source"/> interface to this data row.
		/// </summary>
		public void Copy_From_But_Ignore(IDoubleTransition source, params string[] excludedColumns)
		{
			if (!excludedColumns.Contains(DoubleTransitionsTable.IdCol)) this.Id = source.Id;
			if (!excludedColumns.Contains(DoubleTransitionsTable.PageIdCol)) this.PageId = source.PageId;
			if (!excludedColumns.Contains(DoubleTransitionsTable.BeginnTimeSecondsCol)) this.BeginnTimeSeconds = source.BeginnTimeSeconds;
			if (!excludedColumns.Contains(DoubleTransitionsTable.DurationSecondsCol)) this.DurationSeconds = source.DurationSeconds;
			if (!excludedColumns.Contains(DoubleTransitionsTable.FromValueCol)) this.FromValue = source.FromValue;
			if (!excludedColumns.Contains(DoubleTransitionsTable.ToValueCol)) this.ToValue = source.ToValue;
			if (!excludedColumns.Contains(DoubleTransitionsTable.PropertyPathCol)) this.PropertyPath = source.PropertyPath;
			if (!excludedColumns.Contains(DoubleTransitionsTable.TransitionTypeCol)) this.TransitionType = source.TransitionType;
			if (!excludedColumns.Contains(DoubleTransitionsTable.DiagnosticTextCol)) this.DiagnosticText = source.DiagnosticText;
		}
		///	<summary> 
		///		This method copy's each database field which is in the <paramref name="includedColumns"/> 
		///		from the <paramref name="source"/> interface to this data row.
		/// </summary>
		public void Copy_From_But_TakeOnly(IDoubleTransition source, params string[] includedColumns)
		{
			if (includedColumns.Contains(DoubleTransitionsTable.IdCol)) this.Id = source.Id;
			if (includedColumns.Contains(DoubleTransitionsTable.PageIdCol)) this.PageId = source.PageId;
			if (includedColumns.Contains(DoubleTransitionsTable.BeginnTimeSecondsCol)) this.BeginnTimeSeconds = source.BeginnTimeSeconds;
			if (includedColumns.Contains(DoubleTransitionsTable.DurationSecondsCol)) this.DurationSeconds = source.DurationSeconds;
			if (includedColumns.Contains(DoubleTransitionsTable.FromValueCol)) this.FromValue = source.FromValue;
			if (includedColumns.Contains(DoubleTransitionsTable.ToValueCol)) this.ToValue = source.ToValue;
			if (includedColumns.Contains(DoubleTransitionsTable.PropertyPathCol)) this.PropertyPath = source.PropertyPath;
			if (includedColumns.Contains(DoubleTransitionsTable.TransitionTypeCol)) this.TransitionType = source.TransitionType;
			if (includedColumns.Contains(DoubleTransitionsTable.DiagnosticTextCol)) this.DiagnosticText = source.DiagnosticText;
		}
		
		///	<summary>Creates a new instance of type <see cref="Poco_DoubleTransition" />.</summary>
		public Poco_DoubleTransition AsPoco()
		{
			Poco_DoubleTransition poco = new Poco_DoubleTransition();
			Copy_To(poco, true);
			return poco;
		}
	}
}