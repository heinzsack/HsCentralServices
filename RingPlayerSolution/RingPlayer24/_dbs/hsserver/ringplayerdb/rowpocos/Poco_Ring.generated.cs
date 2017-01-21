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
//<date>2017-01-21 20:15:00</date>



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
using RingPlayer24._dbs.hsserver.ringplayerdb.rowinterfaces;
using Poco_Ring=RingPlayer24._dbs.hsserver.ringplayerdb.rowpocos.Poco_Ring;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rowpocos
{
	public partial class Poco_Ring : IRing, INotifyPropertyChanged
	{
		private Guid _id;
		private DateTime _creationDate;
		private DateTime _targetDate;
		private String _diagnosticText;
	
	
	
		///<summary> 
		///		[<c>RingPlayerDb</c>].[<c>Rings</c>].[<c>Id</c>] (Type = <c>uniqueidentifier</c>) 
		///</summary>
		public Guid Id 
		{
			get { return _id; }
			set { SetProperty(ref _id, value, nameof(Id)); }
		}
		///<summary> 
		///		[<c>RingPlayerDb</c>].[<c>Rings</c>].[<c>CreationDate</c>] (Type = <c>datetime2</c>) 
		///</summary>
		public DateTime CreationDate 
		{
			get { return _creationDate; }
			set { SetProperty(ref _creationDate, value, nameof(CreationDate)); }
		}
		///<summary> 
		///		[<c>RingPlayerDb</c>].[<c>Rings</c>].[<c>TargetDate</c>] (Type = <c>datetime2</c>) 
		///</summary>
		public DateTime TargetDate 
		{
			get { return _targetDate; }
			set { SetProperty(ref _targetDate, value, nameof(TargetDate)); }
		}
		///<summary> 
		///		[<c>RingPlayerDb</c>].[<c>Rings</c>].[<c>DiagnosticText</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String DiagnosticText 
		{
			get { return _diagnosticText; }
			set { SetProperty(ref _diagnosticText, value, nameof(DiagnosticText)); }
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