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
//<date>2016-10-11 17:43:35</date>



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
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.dataset;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.tables;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rowinterfaces;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rowpocos;






namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows
{
	#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	
	///<summary>DataRow([<c>RingPlayerDb</c>].[<c>Pages</c>]): row model of <see cref="PagesTable"/>.</summary>
	[Serializable]
	[DebuggerStepThrough]
	[DebuggerDisplay("DataRow(RingPlayerDb.Pages): Id = '{Id}'")]
	[CsDbDataRow(Database = "RingPlayerDb", TableName = "Pages", Generated = "16.10.11 17:43:35", Hash = "0772B608C49D2648AED50BEE14DBBD7E")]
	public partial class Page : CsDbTableRow, IPage
	{
		#region statics
		private static Dictionary<string, System.Reflection.PropertyInfo> _nativeColumnName_To_Property;
		public static Dictionary<string, System.Reflection.PropertyInfo> NativeColumnName_To_Property
		{
			get
			{
				if (_nativeColumnName_To_Property != null)
					return _nativeColumnName_To_Property;
		
				var type = typeof(IPage);
				_nativeColumnName_To_Property = new Dictionary<string, System.Reflection.PropertyInfo>
				{
					{ PagesTable.IdCol, type.GetProperty(nameof(Id)) },
					{ PagesTable.DiagnosticTextCol, type.GetProperty(nameof(DiagnosticText)) },
					{ PagesTable.ParentPageIdCol, type.GetProperty(nameof(ParentPageId)) },
					{ PagesTable.PageGroupIdCol, type.GetProperty(nameof(PageGroupId)) },
					{ PagesTable.SortOrderCol, type.GetProperty(nameof(SortOrder)) },
					{ PagesTable.MarginThicknessCol, type.GetProperty(nameof(MarginThickness)) },
					{ PagesTable.BorderThicknessCol, type.GetProperty(nameof(BorderThickness)) },
					{ PagesTable.BackgroundCol, type.GetProperty(nameof(Background)) },
					{ PagesTable.BorderColorCol, type.GetProperty(nameof(BorderColor)) },
					{ PagesTable.RotationCol, type.GetProperty(nameof(Rotation)) },
					{ PagesTable.HasFixedRatioCol, type.GetProperty(nameof(HasFixedRatio)) },
					{ PagesTable.RatioXCol, type.GetProperty(nameof(RatioX)) },
					{ PagesTable.RatioYCol, type.GetProperty(nameof(RatioY)) },
					{ PagesTable.ExpectedDurationCol, type.GetProperty(nameof(ExpectedDuration)) }
				};
		
				return _nativeColumnName_To_Property;
			}
		}
		#endregion
	
	
		public Page(DataRowBuilder builder) : base(builder){}
	
		
		///<summary>References the owning data context, this is equal to the database server. Use this to address databases on the same server.</summary>
		public new HsCentralServiceWebInterfacesServer._dbs.hsserver.HsServerContext DataContext => Table.DataContext;
	
		///<summary>References the owning dataset. Use this to address tables in the same database</summary>
		public new RingPlayerDb DataSet => Table.DataSet;
	
		///	<summary>Gets the owning table of type <see cref="PagesTable"/>.</summary>
		public new PagesTable Table => (PagesTable) base.Table;
	
	
	
	
		#region COLUMNS
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>Id</c>] (Type = <c>uniqueidentifier</c>, Default = '<c>(newid())</c>')
		///</summary>
		[CsDbDataColumn(Default = "Guid.NewGuid()")]
		[CsDbNativeDataColumn(Table = "Pages", Name = "Id", Type = "uniqueidentifier", Default = "(newid())", IsNullable = "NO")]
		public Guid Id
		{
			get { return GetDbValue<Guid>(PagesTable.IdCol); }
			set { SetDbValue(value, PagesTable.IdCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>DiagnosticText</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>)
		///</summary>
		[CsDbDataColumn(IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Pages", Name = "DiagnosticText", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES")]
		public String DiagnosticText
		{
			get { return GetDbValue<String>(PagesTable.DiagnosticTextCol); }
			set { SetDbValue(value, PagesTable.DiagnosticTextCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>ParentPageId</c>] (Type = <c>uniqueidentifier</c>, <c>NULLABLE</c>)
		///</summary>
		[CsDbDataColumn(IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Pages", Name = "ParentPageId", Type = "uniqueidentifier", IsNullable = "YES")]
		public Guid? ParentPageId
		{
			get { return GetDbValue<Guid?>(PagesTable.ParentPageIdCol); }
			set { SetDbValue(value, PagesTable.ParentPageIdCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>PageGroupId</c>] (Type = <c>uniqueidentifier</c>)
		///</summary>
		[CsDbDataColumn]
		[CsDbNativeDataColumn(Table = "Pages", Name = "PageGroupId", Type = "uniqueidentifier", IsNullable = "NO")]
		public Guid PageGroupId
		{
			get { return GetDbValue<Guid>(PagesTable.PageGroupIdCol); }
			set { SetDbValue(value, PagesTable.PageGroupIdCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>SortOrder</c>] (Type = <c>int</c>, Default = '<c>((0))</c>')
		///</summary>
		[CsDbDataColumn(Default = 0)]
		[CsDbNativeDataColumn(Table = "Pages", Name = "SortOrder", Type = "int", Default = "((0))", IsNullable = "NO")]
		public Int32 SortOrder
		{
			get { return GetDbValue<Int32>(PagesTable.SortOrderCol); }
			set { SetDbValue(value, PagesTable.SortOrderCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>MarginThickness</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>256</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 256, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Pages", Name = "MarginThickness", Type = "nvarchar", MaxLength = "256", IsNullable = "YES")]
		public String MarginThickness
		{
			get { return GetDbValue<String>(PagesTable.MarginThicknessCol); }
			set { SetDbValue(value, PagesTable.MarginThicknessCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>BorderThickness</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>256</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 256, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Pages", Name = "BorderThickness", Type = "nvarchar", MaxLength = "256", IsNullable = "YES")]
		public String BorderThickness
		{
			get { return GetDbValue<String>(PagesTable.BorderThicknessCol); }
			set { SetDbValue(value, PagesTable.BorderThicknessCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>Background</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>255</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 255, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Pages", Name = "Background", Type = "nvarchar", MaxLength = "255", IsNullable = "YES")]
		public String Background
		{
			get { return GetDbValue<String>(PagesTable.BackgroundCol); }
			set { SetDbValue(value, PagesTable.BackgroundCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>BorderColor</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>255</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 255, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Pages", Name = "BorderColor", Type = "nvarchar", MaxLength = "255", IsNullable = "YES")]
		public String BorderColor
		{
			get { return GetDbValue<String>(PagesTable.BorderColorCol); }
			set { SetDbValue(value, PagesTable.BorderColorCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>Rotation</c>] (Type = <c>float</c>, Default = '<c>((0))</c>')
		///</summary>
		[CsDbDataColumn(Default = 0)]
		[CsDbNativeDataColumn(Table = "Pages", Name = "Rotation", Type = "float", Default = "((0))", IsNullable = "NO")]
		public Double Rotation
		{
			get { return GetDbValue<Double>(PagesTable.RotationCol); }
			set { SetDbValue(value, PagesTable.RotationCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>HasFixedRatio</c>] (Type = <c>bit</c>, Default = '<c>((0))</c>')
		///</summary>
		[CsDbDataColumn(Default = false)]
		[CsDbNativeDataColumn(Table = "Pages", Name = "HasFixedRatio", Type = "bit", Default = "((0))", IsNullable = "NO")]
		public Boolean HasFixedRatio
		{
			get { return GetDbValue<Boolean>(PagesTable.HasFixedRatioCol); }
			set { SetDbValue(value, PagesTable.HasFixedRatioCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>RatioX</c>] (Type = <c>float</c>, Default = '<c>((0))</c>')
		///</summary>
		[CsDbDataColumn(Default = 0)]
		[CsDbNativeDataColumn(Table = "Pages", Name = "RatioX", Type = "float", Default = "((0))", IsNullable = "NO")]
		public Double RatioX
		{
			get { return GetDbValue<Double>(PagesTable.RatioXCol); }
			set { SetDbValue(value, PagesTable.RatioXCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>RatioY</c>] (Type = <c>float</c>, Default = '<c>((0))</c>')
		///</summary>
		[CsDbDataColumn(Default = 0)]
		[CsDbNativeDataColumn(Table = "Pages", Name = "RatioY", Type = "float", Default = "((0))", IsNullable = "NO")]
		public Double RatioY
		{
			get { return GetDbValue<Double>(PagesTable.RatioYCol); }
			set { SetDbValue(value, PagesTable.RatioYCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>ExpectedDuration</c>] (Type = <c>float</c>, <c>NULLABLE</c>)
		///</summary>
		[CsDbDataColumn(IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Pages", Name = "ExpectedDuration", Type = "float", IsNullable = "YES")]
		public Double? ExpectedDuration
		{
			get { return GetDbValue<Double?>(PagesTable.ExpectedDurationCol); }
			set { SetDbValue(value, PagesTable.ExpectedDurationCol); }
		}
		
		#endregion
	
	
	
	
	
		///	<summary>Reloads the <see cref="Page"/> row by executing following command:<para/><c>$"SELECT * FROM Pages WHERE [Id] = '<see cref="Id"/>'</c></summary>
		public Page Reload()
		{
			Table.DataSet.Pages.LoadThenFind(Id);
			return this;
		}
		
		
		
		
		#region PROPERTIES<Many to One>
		private PageGroup _pageGroup;
		private Page _parentPage;
		private ContractCollection<Image> _weakImages;
		private ContractCollection<Text> _weakTexts;
		private ContractCollection<DoubleTransition> _weakDoubleTransitions;
		private ContractCollection<Page> _weakChildPages;
		private ContractCollection<PageSchedule> _weakPageSchedules;
		private ContractCollection<Video> _weakVideos;
		public bool IsPageGroupLoaded => (_pageGroup == null || _pageGroup.RowState != DataRowState.Detached) && Equals(_pageGroup?.Id, PageGroupId);
		public bool IsParentPageLoaded => (_parentPage == null || _parentPage.RowState != DataRowState.Detached) && Equals(_parentPage?.Id, ParentPageId);
		
		///	<summary>
		///		This field has cached Output.<para/>
		///		<c>SELECT * FROM PageGroups WHERE [Id] = '<paramref name="PageGroupId"/>'</c><para/>[<c>Pages</c>].[<c>PageGroupId</c>] &#62;&#62;&#62;&#62; [<c>PageGroups</c>].[<c>Id</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_Pages_PageGroups", PkTable = "PageGroups", PkColumn = "Id", FkTable = "Pages", FkColumn = "PageGroupId")][DependsOn("PageGroupId")]
		public PageGroup PageGroup
		{
			get 
			{
				if (IsPageGroupLoaded)
					return _pageGroup;
				
				_pageGroup = Table.DataSet.PageGroups.FindOrLoad(PageGroupId);
				return _pageGroup;
			}
			set 
			{
				if (value == null) throw new InvalidOperationException("The value cannot be null (FK: FK_Pages_PageGroups)");
				if (value != null && value.Table.DataSet != Table.DataSet) throw new InvalidOperationException("The owning data set have to be equal.");
				if (value == _pageGroup) return;
		
				_pageGroup = value;
		
				if (value == null)
					SetDbValue(default(Guid), PagesTable.PageGroupIdCol, "PageGroupId");
				else
					SetDbValue(value.Id, PagesTable.PageGroupIdCol, "PageGroupId");
			}
		}
		///	<summary>
		///		This field has cached Output.<para/>
		///		<c>SELECT * FROM Pages WHERE [Id] = '<paramref name="ParentPageId"/>'</c><para/>[<c>Pages</c>].[<c>ParentPageId</c>] &#62;&#62;&#62;&#62; [<c>Pages</c>].[<c>Id</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_Pages_Pages1", PkTable = "Pages", PkColumn = "Id", FkTable = "Pages", FkColumn = "ParentPageId")][DependsOn("ParentPageId")]
		public Page ParentPage
		{
			get 
			{
				if (IsParentPageLoaded)
					return _parentPage;
				if (ParentPageId == null) _parentPage = null; else
				_parentPage = Table.DataSet.Pages.FindOrLoad(ParentPageId.Value);
				return _parentPage;
			}
			set 
			{
				
				if (value != null && value.Table.DataSet != Table.DataSet) throw new InvalidOperationException("The owning data set have to be equal.");
				if (value == _parentPage) return;
		
				_parentPage = value;
		
				if (value == null)
					SetDbValue(default(Guid?), PagesTable.ParentPageIdCol, "ParentPageId");
				else
					SetDbValue(value.Id, PagesTable.ParentPageIdCol, "ParentPageId");
			}
		}
		#endregion
		
		
		
		
		
		#region PROPERTIES<One to Many>
		///	<summary>
		///		This field has cached Output. <para/>
		///		<c>SELECT * FROM Images WHERE [ParentPageId] = '<paramref name="Id"/>'</c><para/>[<c>Pages</c>].[<c>Id</c>] &#60;&#60;&#60;&#60; [<c>Images</c>].[<c>ParentPageId</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_Images_Visuals", PkTable = "Pages", PkColumn = "Id", FkTable = "Images", FkColumn = "ParentPageId")]
		public ContractCollection<Image> Images
		{
			get	{ return _weakImages ?? (_weakImages = Table.DataSet.Images.FindOrLoad_By_ParentPageId(Id)); }
		}
		///	<summary>
		///		This field has cached Output. <para/>
		///		<c>SELECT * FROM Texts WHERE [ParentPageId] = '<paramref name="Id"/>'</c><para/>[<c>Pages</c>].[<c>Id</c>] &#60;&#60;&#60;&#60; [<c>Texts</c>].[<c>ParentPageId</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_Texts_Visuals", PkTable = "Pages", PkColumn = "Id", FkTable = "Texts", FkColumn = "ParentPageId")]
		public ContractCollection<Text> Texts
		{
			get	{ return _weakTexts ?? (_weakTexts = Table.DataSet.Texts.FindOrLoad_By_ParentPageId(Id)); }
		}
		///	<summary>
		///		This field has cached Output. <para/>
		///		<c>SELECT * FROM DoubleTransitions WHERE [PageId] = '<paramref name="Id"/>'</c><para/>[<c>Pages</c>].[<c>Id</c>] &#60;&#60;&#60;&#60; [<c>DoubleTransitions</c>].[<c>PageId</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_DoubleTransitions_Visuals", PkTable = "Pages", PkColumn = "Id", FkTable = "DoubleTransitions", FkColumn = "PageId")]
		public ContractCollection<DoubleTransition> DoubleTransitions
		{
			get	{ return _weakDoubleTransitions ?? (_weakDoubleTransitions = Table.DataSet.DoubleTransitions.FindOrLoad_By_PageId(Id)); }
		}
		///	<summary>
		///		This field has cached Output. <para/>
		///		<c>SELECT * FROM Pages WHERE [ParentPageId] = '<paramref name="Id"/>'</c><para/>[<c>Pages</c>].[<c>Id</c>] &#60;&#60;&#60;&#60; [<c>Pages</c>].[<c>ParentPageId</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_Pages_Pages1", PkTable = "Pages", PkColumn = "Id", FkTable = "Pages", FkColumn = "ParentPageId")]
		public ContractCollection<Page> ChildPages
		{
			get	{ return _weakChildPages ?? (_weakChildPages = Table.DataSet.Pages.FindOrLoad_By_ParentPageId(Id)); }
		}
		///	<summary>
		///		This field has cached Output. <para/>
		///		<c>SELECT * FROM PageSchedules WHERE [PageId] = '<paramref name="Id"/>'</c><para/>[<c>Pages</c>].[<c>Id</c>] &#60;&#60;&#60;&#60; [<c>PageSchedules</c>].[<c>PageId</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_ScheduledPages_Pages", PkTable = "Pages", PkColumn = "Id", FkTable = "PageSchedules", FkColumn = "PageId")]
		public ContractCollection<PageSchedule> PageSchedules
		{
			get	{ return _weakPageSchedules ?? (_weakPageSchedules = Table.DataSet.PageSchedules.FindOrLoad_By_PageId(Id)); }
		}
		///	<summary>
		///		This field has cached Output. <para/>
		///		<c>SELECT * FROM Videos WHERE [ParentPageId] = '<paramref name="Id"/>'</c><para/>[<c>Pages</c>].[<c>Id</c>] &#60;&#60;&#60;&#60; [<c>Videos</c>].[<c>ParentPageId</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_Videos_Visuals", PkTable = "Pages", PkColumn = "Id", FkTable = "Videos", FkColumn = "ParentPageId")]
		public ContractCollection<Video> Videos
		{
			get	{ return _weakVideos ?? (_weakVideos = Table.DataSet.Videos.FindOrLoad_By_ParentPageId(Id)); }
		}
		#endregion
		
		
		
		
		
		#region FUNC<Overrides>
		protected void Invalidate()
		{
			if (!IsPropertyChangedHandled)
				return;
		
			OnPropertyChanged("Id");
			OnPropertyChanged("DiagnosticText");
			OnPropertyChanged("ParentPageId");
			OnPropertyChanged("PageGroupId");
			OnPropertyChanged("SortOrder");
			OnPropertyChanged("MarginThickness");
			OnPropertyChanged("BorderThickness");
			OnPropertyChanged("Background");
			OnPropertyChanged("BorderColor");
			OnPropertyChanged("Rotation");
			OnPropertyChanged("HasFixedRatio");
			OnPropertyChanged("RatioX");
			OnPropertyChanged("RatioY");
			OnPropertyChanged("ExpectedDuration");
		}
		///	<summary> Set all values which have default values inside the database to their defaults. This method is automatically invoked if you call <see cref="PagesTable.NewRow"/>. </summary>
		public override void ApplyDefaults()
		{
			Id = Guid.NewGuid();
				SortOrder = 0;
				Rotation = 0;
				HasFixedRatio = false;
				RatioX = 0;
				RatioY = 0;
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
		public void Copy_To(IPage target, bool includePrimaryKey = false)
		{
			if (includePrimaryKey) target.Id = this.Id;
			target.DiagnosticText = this.DiagnosticText;
			target.ParentPageId = this.ParentPageId;
			target.PageGroupId = this.PageGroupId;
			target.SortOrder = this.SortOrder;
			target.MarginThickness = this.MarginThickness;
			target.BorderThickness = this.BorderThickness;
			target.Background = this.Background;
			target.BorderColor = this.BorderColor;
			target.Rotation = this.Rotation;
			target.HasFixedRatio = this.HasFixedRatio;
			target.RatioX = this.RatioX;
			target.RatioY = this.RatioY;
			target.ExpectedDuration = this.ExpectedDuration;
		}
		///	<summary> This method copy's each database field from the <paramref name="source"/> interface to this data row.</summary>
		public void Copy_From(IPage source, bool includePrimaryKey = false)
		{
			if (includePrimaryKey) this.Id = source.Id;
			this.DiagnosticText = source.DiagnosticText;
			this.ParentPageId = source.ParentPageId;
			this.PageGroupId = source.PageGroupId;
			this.SortOrder = source.SortOrder;
			this.MarginThickness = source.MarginThickness;
			this.BorderThickness = source.BorderThickness;
			this.Background = source.Background;
			this.BorderColor = source.BorderColor;
			this.Rotation = source.Rotation;
			this.HasFixedRatio = source.HasFixedRatio;
			this.RatioX = source.RatioX;
			this.RatioY = source.RatioY;
			this.ExpectedDuration = source.ExpectedDuration;
		}
		///	<summary> 
		///		This method copy's each database field which is not in the <paramref name="excludedColumns"/> 
		///		from the <paramref name="source"/> interface to this data row.
		/// </summary>
		public void Copy_From_But_Ignore(IPage source, params string[] excludedColumns)
		{
			if (!excludedColumns.Contains(PagesTable.IdCol)) this.Id = source.Id;
			if (!excludedColumns.Contains(PagesTable.DiagnosticTextCol)) this.DiagnosticText = source.DiagnosticText;
			if (!excludedColumns.Contains(PagesTable.ParentPageIdCol)) this.ParentPageId = source.ParentPageId;
			if (!excludedColumns.Contains(PagesTable.PageGroupIdCol)) this.PageGroupId = source.PageGroupId;
			if (!excludedColumns.Contains(PagesTable.SortOrderCol)) this.SortOrder = source.SortOrder;
			if (!excludedColumns.Contains(PagesTable.MarginThicknessCol)) this.MarginThickness = source.MarginThickness;
			if (!excludedColumns.Contains(PagesTable.BorderThicknessCol)) this.BorderThickness = source.BorderThickness;
			if (!excludedColumns.Contains(PagesTable.BackgroundCol)) this.Background = source.Background;
			if (!excludedColumns.Contains(PagesTable.BorderColorCol)) this.BorderColor = source.BorderColor;
			if (!excludedColumns.Contains(PagesTable.RotationCol)) this.Rotation = source.Rotation;
			if (!excludedColumns.Contains(PagesTable.HasFixedRatioCol)) this.HasFixedRatio = source.HasFixedRatio;
			if (!excludedColumns.Contains(PagesTable.RatioXCol)) this.RatioX = source.RatioX;
			if (!excludedColumns.Contains(PagesTable.RatioYCol)) this.RatioY = source.RatioY;
			if (!excludedColumns.Contains(PagesTable.ExpectedDurationCol)) this.ExpectedDuration = source.ExpectedDuration;
		}
		///	<summary> 
		///		This method copy's each database field which is in the <paramref name="includedColumns"/> 
		///		from the <paramref name="source"/> interface to this data row.
		/// </summary>
		public void Copy_From_But_TakeOnly(IPage source, params string[] includedColumns)
		{
			if (includedColumns.Contains(PagesTable.IdCol)) this.Id = source.Id;
			if (includedColumns.Contains(PagesTable.DiagnosticTextCol)) this.DiagnosticText = source.DiagnosticText;
			if (includedColumns.Contains(PagesTable.ParentPageIdCol)) this.ParentPageId = source.ParentPageId;
			if (includedColumns.Contains(PagesTable.PageGroupIdCol)) this.PageGroupId = source.PageGroupId;
			if (includedColumns.Contains(PagesTable.SortOrderCol)) this.SortOrder = source.SortOrder;
			if (includedColumns.Contains(PagesTable.MarginThicknessCol)) this.MarginThickness = source.MarginThickness;
			if (includedColumns.Contains(PagesTable.BorderThicknessCol)) this.BorderThickness = source.BorderThickness;
			if (includedColumns.Contains(PagesTable.BackgroundCol)) this.Background = source.Background;
			if (includedColumns.Contains(PagesTable.BorderColorCol)) this.BorderColor = source.BorderColor;
			if (includedColumns.Contains(PagesTable.RotationCol)) this.Rotation = source.Rotation;
			if (includedColumns.Contains(PagesTable.HasFixedRatioCol)) this.HasFixedRatio = source.HasFixedRatio;
			if (includedColumns.Contains(PagesTable.RatioXCol)) this.RatioX = source.RatioX;
			if (includedColumns.Contains(PagesTable.RatioYCol)) this.RatioY = source.RatioY;
			if (includedColumns.Contains(PagesTable.ExpectedDurationCol)) this.ExpectedDuration = source.ExpectedDuration;
		}
		
		///	<summary>Creates a new instance of type <see cref="Poco_Page" />.</summary>
		public Poco_Page AsPoco()
		{
			Poco_Page poco = new Poco_Page();
			Copy_To(poco, true);
			return poco;
		}
	}
}