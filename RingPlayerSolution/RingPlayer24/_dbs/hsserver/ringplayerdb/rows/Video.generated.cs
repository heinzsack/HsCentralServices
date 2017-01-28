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
using RingPlayer24._dbs.hsserver.ringplayerdb.tables;
using RingPlayer24._dbs.hsserver.ringplayerdb.rowinterfaces;
using RingPlayer24._dbs.hsserver.ringplayerdb.rowpocos;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rows
{
	#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	
	///<summary>DataRow([<c>RingPlayerDb</c>].[<c>Videos</c>]): row model of <see cref="VideosTable"/>.</summary>
	[Serializable]
	[DebuggerDisplay("DataRow(RingPlayerDb.Videos): Id = '{Id}'")]
	[CsDbDataRow(Database = "RingPlayerDb", TableName = "Videos", Generated = "17.01.26 17:28:57", Hash = "E70E8B2E478C62088CCA05F3669BAF56")]
	public partial class Video : CsDbTableRow, IVideo
	{
		#region statics
		private static Dictionary<string, System.Reflection.PropertyInfo> _nativeColumnName_To_Property;
		public static Dictionary<string, System.Reflection.PropertyInfo> NativeColumnName_To_Property
		{
			get
			{
				if (_nativeColumnName_To_Property != null)
					return _nativeColumnName_To_Property;
		
				var type = typeof(IVideo);
				_nativeColumnName_To_Property = new Dictionary<string, System.Reflection.PropertyInfo>
				{
					{ VideosTable.IdCol, type.GetProperty(nameof(Id)) },
					{ VideosTable.PageIdCol, type.GetProperty(nameof(PageId)) },
					{ VideosTable.VideoIdCol, type.GetProperty(nameof(VideoId)) },
					{ VideosTable.SortOrderCol, type.GetProperty(nameof(SortOrder)) },
					{ VideosTable.MarginThicknessCol, type.GetProperty(nameof(MarginThickness)) },
					{ VideosTable.BorderThicknessCol, type.GetProperty(nameof(BorderThickness)) },
					{ VideosTable.BackgroundCol, type.GetProperty(nameof(Background)) },
					{ VideosTable.BorderColorCol, type.GetProperty(nameof(BorderColor)) },
					{ VideosTable.RotationCol, type.GetProperty(nameof(Rotation)) },
					{ VideosTable.DiagnosticTextCol, type.GetProperty(nameof(DiagnosticText)) }
				};
		
				return _nativeColumnName_To_Property;
			}
		}
		#endregion
	
	
		public Video(DataRowBuilder builder) : base(builder){}
	
		
		///<summary>References the owning data context, this is equal to the database server. Use this to address databases on the same server.</summary>
		public new RingPlayer24._dbs.hsserver.HsServerContext DataContext => Table.DataContext;
	
		///<summary>References the owning dataset. Use this to address tables in the same database</summary>
		public new RingPlayerDb DataSet => Table.DataSet;
	
		///	<summary>Gets the owning table of type <see cref="VideosTable"/>.</summary>
		public new VideosTable Table => (VideosTable) base.Table;
	
	
	
	
		#region COLUMNS
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Videos</c>].[<c>Id</c>] (Type = <c>uniqueidentifier</c>, Default = '<c>(newid())</c>')
		///</summary>
		[CsDbDataColumn(Default = "Guid.NewGuid()")]
		[CsDbNativeDataColumn(Table = "Videos", Name = "Id", Type = "uniqueidentifier", Default = "(newid())", IsNullable = "NO")]
		public Guid Id
		{
			[DebuggerStepThrough] get { return GetDbValue<Guid>(VideosTable.IdCol); }
			[DebuggerStepThrough] set { SetDbValue(value, VideosTable.IdCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Videos</c>].[<c>PageId</c>] (Type = <c>uniqueidentifier</c>)
		///</summary>
		[CsDbDataColumn]
		[CsDbNativeDataColumn(Table = "Videos", Name = "PageId", Type = "uniqueidentifier", IsNullable = "NO")]
		public Guid PageId
		{
			[DebuggerStepThrough] get { return GetDbValue<Guid>(VideosTable.PageIdCol); }
			[DebuggerStepThrough] set { SetDbValue(value, VideosTable.PageIdCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Videos</c>].[<c>VideoId</c>] (Type = <c>uniqueidentifier</c>)
		///</summary>
		[CsDbDataColumn]
		[CsDbNativeDataColumn(Table = "Videos", Name = "VideoId", Type = "uniqueidentifier", IsNullable = "NO")]
		public Guid VideoId
		{
			[DebuggerStepThrough] get { return GetDbValue<Guid>(VideosTable.VideoIdCol); }
			[DebuggerStepThrough] set { SetDbValue(value, VideosTable.VideoIdCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Videos</c>].[<c>SortOrder</c>] (Type = <c>int</c>, Default = '<c>((0))</c>')
		///</summary>
		[CsDbDataColumn(Default = 0)]
		[CsDbNativeDataColumn(Table = "Videos", Name = "SortOrder", Type = "int", Default = "((0))", IsNullable = "NO")]
		public Int32 SortOrder
		{
			[DebuggerStepThrough] get { return GetDbValue<Int32>(VideosTable.SortOrderCol); }
			[DebuggerStepThrough] set { SetDbValue(value, VideosTable.SortOrderCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Videos</c>].[<c>MarginThickness</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>256</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 256, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Videos", Name = "MarginThickness", Type = "nvarchar", MaxLength = "256", IsNullable = "YES")]
		public String MarginThickness
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(VideosTable.MarginThicknessCol); }
			[DebuggerStepThrough] set { SetDbValue(value, VideosTable.MarginThicknessCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Videos</c>].[<c>BorderThickness</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>256</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 256, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Videos", Name = "BorderThickness", Type = "nvarchar", MaxLength = "256", IsNullable = "YES")]
		public String BorderThickness
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(VideosTable.BorderThicknessCol); }
			[DebuggerStepThrough] set { SetDbValue(value, VideosTable.BorderThicknessCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Videos</c>].[<c>Background</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>50</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 50, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Videos", Name = "Background", Type = "nvarchar", MaxLength = "50", IsNullable = "YES")]
		public String Background
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(VideosTable.BackgroundCol); }
			[DebuggerStepThrough] set { SetDbValue(value, VideosTable.BackgroundCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Videos</c>].[<c>BorderColor</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>50</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 50, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Videos", Name = "BorderColor", Type = "nvarchar", MaxLength = "50", IsNullable = "YES")]
		public String BorderColor
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(VideosTable.BorderColorCol); }
			[DebuggerStepThrough] set { SetDbValue(value, VideosTable.BorderColorCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Videos</c>].[<c>Rotation</c>] (Type = <c>float</c>, Default = '<c>((0))</c>')
		///</summary>
		[CsDbDataColumn(Default = 0)]
		[CsDbNativeDataColumn(Table = "Videos", Name = "Rotation", Type = "float", Default = "((0))", IsNullable = "NO")]
		public Double Rotation
		{
			[DebuggerStepThrough] get { return GetDbValue<Double>(VideosTable.RotationCol); }
			[DebuggerStepThrough] set { SetDbValue(value, VideosTable.RotationCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Videos</c>].[<c>DiagnosticText</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>)
		///</summary>
		[CsDbDataColumn(IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Videos", Name = "DiagnosticText", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES")]
		public String DiagnosticText
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(VideosTable.DiagnosticTextCol); }
			[DebuggerStepThrough] set { SetDbValue(value, VideosTable.DiagnosticTextCol); }
		}
		
		#endregion
	
	
	
	
	
		///	<summary>Reloads the <see cref="Video"/> row by executing following command:<para/><c>$"SELECT * FROM Videos WHERE [Id] = '<see cref="Id"/>'</c></summary>
		public Video Reload()
		{
			Table.DataSet.Videos.LoadThenFind(Id);
			return this;
		}
		
		
		
		
		#region PROPERTIES<Many to One>
		private Page _page;
		public bool IsPageLoaded => (_page == null || _page.RowState != DataRowState.Detached) && Equals(_page?.Id, PageId);
		
		///	<summary>
		///		This field has cached Output.<para/>
		///		<c>SELECT * FROM Pages WHERE [Id] = '<paramref name="PageId"/>'</c><para/>[<c>Videos</c>].[<c>PageId</c>] &#62;&#62;&#62;&#62; [<c>Pages</c>].[<c>Id</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_Videos_Visuals", PkTable = "Pages", PkColumn = "Id", FkTable = "Videos", FkColumn = "PageId")][DependsOn("PageId")]
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
				if (value == null) throw new InvalidOperationException("The value cannot be null (FK: FK_Videos_Visuals)");
				if (value != null && value.Table.DataSet != Table.DataSet) throw new InvalidOperationException("The owning data set have to be equal.");
				if (value == _page) return;
		
				_page = value;
		
				if (value == null)
					SetDbValue(default(Guid), VideosTable.PageIdCol, "PageId");
				else
					SetDbValue(value.Id, VideosTable.PageIdCol, "PageId");
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
			OnPropertyChanged("VideoId");
			OnPropertyChanged("SortOrder");
			OnPropertyChanged("MarginThickness");
			OnPropertyChanged("BorderThickness");
			OnPropertyChanged("Background");
			OnPropertyChanged("BorderColor");
			OnPropertyChanged("Rotation");
			OnPropertyChanged("DiagnosticText");
		}
		///	<summary> Set all values which have default values inside the database to their defaults. This method is automatically invoked if you call <see cref="VideosTable.NewRow"/>. </summary>
		public override void ApplyDefaults()
		{
			Id = Guid.NewGuid();
				SortOrder = 0;
				Rotation = 0;
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
		public void Copy_To(IVideo target, bool includePrimaryKey = false)
		{
			if (includePrimaryKey) target.Id = this.Id;
			target.PageId = this.PageId;
			target.VideoId = this.VideoId;
			target.SortOrder = this.SortOrder;
			target.MarginThickness = this.MarginThickness;
			target.BorderThickness = this.BorderThickness;
			target.Background = this.Background;
			target.BorderColor = this.BorderColor;
			target.Rotation = this.Rotation;
			target.DiagnosticText = this.DiagnosticText;
		}
		///	<summary> This method copy's each database field from the <paramref name="source"/> interface to this data row.</summary>
		public void Copy_From(IVideo source, bool includePrimaryKey = false)
		{
			if (includePrimaryKey) this.Id = source.Id;
			this.PageId = source.PageId;
			this.VideoId = source.VideoId;
			this.SortOrder = source.SortOrder;
			this.MarginThickness = source.MarginThickness;
			this.BorderThickness = source.BorderThickness;
			this.Background = source.Background;
			this.BorderColor = source.BorderColor;
			this.Rotation = source.Rotation;
			this.DiagnosticText = source.DiagnosticText;
		}
		///	<summary> 
		///		This method copy's each database field which is not in the <paramref name="excludedColumns"/> 
		///		from the <paramref name="source"/> interface to this data row.
		/// </summary>
		public void Copy_From_But_Ignore(IVideo source, params string[] excludedColumns)
		{
			if (!excludedColumns.Contains(VideosTable.IdCol)) this.Id = source.Id;
			if (!excludedColumns.Contains(VideosTable.PageIdCol)) this.PageId = source.PageId;
			if (!excludedColumns.Contains(VideosTable.VideoIdCol)) this.VideoId = source.VideoId;
			if (!excludedColumns.Contains(VideosTable.SortOrderCol)) this.SortOrder = source.SortOrder;
			if (!excludedColumns.Contains(VideosTable.MarginThicknessCol)) this.MarginThickness = source.MarginThickness;
			if (!excludedColumns.Contains(VideosTable.BorderThicknessCol)) this.BorderThickness = source.BorderThickness;
			if (!excludedColumns.Contains(VideosTable.BackgroundCol)) this.Background = source.Background;
			if (!excludedColumns.Contains(VideosTable.BorderColorCol)) this.BorderColor = source.BorderColor;
			if (!excludedColumns.Contains(VideosTable.RotationCol)) this.Rotation = source.Rotation;
			if (!excludedColumns.Contains(VideosTable.DiagnosticTextCol)) this.DiagnosticText = source.DiagnosticText;
		}
		///	<summary> 
		///		This method copy's each database field which is in the <paramref name="includedColumns"/> 
		///		from the <paramref name="source"/> interface to this data row.
		/// </summary>
		public void Copy_From_But_TakeOnly(IVideo source, params string[] includedColumns)
		{
			if (includedColumns.Contains(VideosTable.IdCol)) this.Id = source.Id;
			if (includedColumns.Contains(VideosTable.PageIdCol)) this.PageId = source.PageId;
			if (includedColumns.Contains(VideosTable.VideoIdCol)) this.VideoId = source.VideoId;
			if (includedColumns.Contains(VideosTable.SortOrderCol)) this.SortOrder = source.SortOrder;
			if (includedColumns.Contains(VideosTable.MarginThicknessCol)) this.MarginThickness = source.MarginThickness;
			if (includedColumns.Contains(VideosTable.BorderThicknessCol)) this.BorderThickness = source.BorderThickness;
			if (includedColumns.Contains(VideosTable.BackgroundCol)) this.Background = source.Background;
			if (includedColumns.Contains(VideosTable.BorderColorCol)) this.BorderColor = source.BorderColor;
			if (includedColumns.Contains(VideosTable.RotationCol)) this.Rotation = source.Rotation;
			if (includedColumns.Contains(VideosTable.DiagnosticTextCol)) this.DiagnosticText = source.DiagnosticText;
		}
		
		///	<summary>Creates a new instance of type <see cref="Poco_Video" />.</summary>
		public Poco_Video AsPoco()
		{
			Poco_Video poco = new Poco_Video();
			Copy_To(poco, true);
			return poco;
		}
	}
}