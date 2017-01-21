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
//<date>2017-01-21 20:14:59</date>



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
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rowinterfaces;
using Poco_RepositoryFile=HsCentralServiceWeb._dbs.hsserver.centralservicedb.rowpocos.Poco_RepositoryFile;






namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.rowpocos
{
	public partial class Poco_RepositoryFile : IRepositoryFile, INotifyPropertyChanged
	{
		private Guid _id;
		private String _hash;
		private String _path;
		private Boolean _isDownloadAble;
		private String _name;
		private String _extension;
		private String _description;
		private String _author;
		private Guid _authorId;
		private Int32 _length;
		private DateTime _created;
		private Double _uploadDuration;
		private DateTime? _modified;
		private String _group;
		private DateTime? _timeToLive;
		private DateTime? _accessDate;
		private Int32? _accessCount;
		private String _lastAccessBy;
		private Guid? _lastAccessById;
	
	
	
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Id</c>] (Type = <c>uniqueidentifier</c>, Default = '<c>(newid())</c>') 
		///</summary>
		public Guid Id 
		{
			get { return _id; }
			set { SetProperty(ref _id, value, nameof(Id)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Hash</c>] (Type = <c>char</c>, MaxLength = <c>40</c>) 
		///</summary>
		public String Hash 
		{
			get { return _hash; }
			set { SetProperty(ref _hash, value, nameof(Hash)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Path</c>] (Type = <c>nvarchar</c>, MaxLength = <c>600</c>) 
		///</summary>
		public String Path 
		{
			get { return _path; }
			set { SetProperty(ref _path, value, nameof(Path)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>IsDownloadAble</c>] (Type = <c>bit</c>, Default = '<c>((1))</c>') 
		///</summary>
		public Boolean IsDownloadAble 
		{
			get { return _isDownloadAble; }
			set { SetProperty(ref _isDownloadAble, value, nameof(IsDownloadAble)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Name</c>] (Type = <c>nvarchar</c>, MaxLength = <c>200</c>) 
		///</summary>
		public String Name 
		{
			get { return _name; }
			set { SetProperty(ref _name, value, nameof(Name)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Extension</c>] (Type = <c>nvarchar</c>, MaxLength = <c>100</c>) 
		///</summary>
		public String Extension 
		{
			get { return _extension; }
			set { SetProperty(ref _extension, value, nameof(Extension)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Description</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>1000</c>) 
		///</summary>
		public String Description 
		{
			get { return _description; }
			set { SetProperty(ref _description, value, nameof(Description)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Author</c>] (Type = <c>nvarchar</c>, MaxLength = <c>600</c>) 
		///</summary>
		public String Author 
		{
			get { return _author; }
			set { SetProperty(ref _author, value, nameof(Author)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>AuthorId</c>] (Type = <c>uniqueidentifier</c>) 
		///</summary>
		public Guid AuthorId 
		{
			get { return _authorId; }
			set { SetProperty(ref _authorId, value, nameof(AuthorId)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Length</c>] (Type = <c>int</c>) 
		///</summary>
		public Int32 Length 
		{
			get { return _length; }
			set { SetProperty(ref _length, value, nameof(Length)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Created</c>] (Type = <c>datetime2</c>) 
		///</summary>
		public DateTime Created 
		{
			get { return _created; }
			set { SetProperty(ref _created, value, nameof(Created)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>UploadDuration</c>] (Type = <c>float</c>) 
		///</summary>
		public Double UploadDuration 
		{
			get { return _uploadDuration; }
			set { SetProperty(ref _uploadDuration, value, nameof(UploadDuration)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Modified</c>] (Type = <c>datetime2</c>, <c>NULLABLE</c>) 
		///</summary>
		public DateTime? Modified 
		{
			get { return _modified; }
			set { SetProperty(ref _modified, value, nameof(Modified)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Group</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>200</c>) 
		///</summary>
		public String Group 
		{
			get { return _group; }
			set { SetProperty(ref _group, value, nameof(Group)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>TimeToLive</c>] (Type = <c>datetime2</c>, <c>NULLABLE</c>) 
		///</summary>
		public DateTime? TimeToLive 
		{
			get { return _timeToLive; }
			set { SetProperty(ref _timeToLive, value, nameof(TimeToLive)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>AccessDate</c>] (Type = <c>datetime2</c>, <c>NULLABLE</c>) 
		///</summary>
		public DateTime? AccessDate 
		{
			get { return _accessDate; }
			set { SetProperty(ref _accessDate, value, nameof(AccessDate)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>AccessCount</c>] (Type = <c>int</c>, <c>NULLABLE</c>) 
		///</summary>
		public Int32? AccessCount 
		{
			get { return _accessCount; }
			set { SetProperty(ref _accessCount, value, nameof(AccessCount)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>LastAccessBy</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>600</c>) 
		///</summary>
		public String LastAccessBy 
		{
			get { return _lastAccessBy; }
			set { SetProperty(ref _lastAccessBy, value, nameof(LastAccessBy)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>LastAccessById</c>] (Type = <c>uniqueidentifier</c>, <c>NULLABLE</c>) 
		///</summary>
		public Guid? LastAccessById 
		{
			get { return _lastAccessById; }
			set { SetProperty(ref _lastAccessById, value, nameof(LastAccessById)); }
		}
		
	
	
	
	
	
	
	#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		///     Implementation of the <see cref="INotifyPropertyChanged" /> interface. Checks whether the backing field
		///     already provides this reference or value. If backing field provides the same value, no notification is sent, if you
		///     want to force a notification use <see cref="OnPropertyChanged" />
		/// </summary>
		/// <typeparam name="T">the generic controller, used to provide intellisense feature.</typeparam>
		/// <param name="backingField">The backing field where the property stores the reference</param>
		/// <param name="value">The new value.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		protected virtual bool SetProperty<T>(ref T backingField, T value, string propertyName)
		{
			if (Equals(backingField, value))
				return false;
	
			backingField = value;
			OnPropertyChanged(propertyName);
			return true;
		}
		/// <summary>Sends a notification to <see cref="PropertyChanged" /> subscriber.</summary>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler onPropertyChanged = PropertyChanged;
			if (onPropertyChanged != null)
			{
				onPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	#endregion
	}
}