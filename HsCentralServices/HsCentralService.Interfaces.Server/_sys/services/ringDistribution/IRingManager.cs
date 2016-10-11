// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-20</date>

using System;
using System.Collections.Generic;
using System.IO;

namespace HsCentralServiceInterfacesServer._sys.services.ringDistribution
	{
	/// <summary>Used on the central service for filling and updateing rings which should be played on a player.</summary>
	public interface IRingManager
		{
		#region Abstract

		/// <summary>Initializes the database, and other tools for further use.</summary>
		/// <param name="rcData">All Data Context</param>
		void Initialize(RingCommunicationData rcData);

		/// <summary>
		///     Generates a complete new ring into the provided <paramref name="ring" /> dataset. This should produce a complete 24 hour active ring which has no
		///     other logic then playing the right things at the right time, independet of the past.
		/// </summary>
		/// <param name="rcData">All Data Context</param>
		/// <param name="computerName">The name of the computer this ring is generated for.</param>
		/// <param name="ring">The target ring where all the generated data should be inserted at.</param>
		/// <remarks>
		///     Things which need to be done:
		///     <para>Set <see cref="RingMetaData.SenderId" /> to the targeting sender id.</para>
		///     <para>Generate <see cref="PageGroup" />s inside the database.</para>
		///     <para>
		///         Generate <see cref="DbEntities.dbserver3.wpmediaaddondata.rows.Page" />s with the associated content (<see cref="DbEntities.dbserver3.mbrwahl.rows.Text" />, <see cref="Image" /> <see cref="Video" />,
		///         <see cref="DoubleTransition" />).
		///     </para>
		///     <para>
		///         Generate <see cref="PageSchedule" />s. <see cref="PageSchedule" />s in sequence which belongs to the same <see cref="PageGroup" /> needs to
		///         have the same <see cref="PageSchedule.PageGroupScheduleId" />.
		///     </para>
		/// </remarks>
		void Generate(RingCommunicationData rcData, string computerName, RingMetaData ring);

		void Update(RingCommunicationData rcData, string computerName, RingMetaData ring);

		PageGroup GeneratePageGroup(RingCommunicationData rcData,
			Guid mmUnitId, RingMetaData ring);

		/// <summary>Should return an always valid file path for the given <paramref name="id" />.</summary>
		/// <param name="rcData">All Data Context</param>
		/// <param name="id">the unique identifier for the targeted image.</param>
		FileInfo GetImageFilePath(RingCommunicationData rcData, Guid id);
		/// <summary>Should return an always valid file path for the given <paramref name="id" />.</summary>
		/// <param name="rcData">All Data Context</param>
		/// <param name="id">the unique identifier for the targeted image.</param>
		Stream GetImageStream(RingCommunicationData rcData, Guid id);

		/// <summary>Should return an always valid file path for the given <paramref name="id" />.</summary>
		/// <param name="rcData">All Data Context</param>
		/// <param name="id">the unique identifier for the targeted video.</param>
		FileInfo GetVideoFilePath(RingCommunicationData rcData, Guid id);

		/// <summary>Should return a String with the SlotDescription for the given <paramref name="slotId" />.</summary>
		/// <param name="rcData">All Data Context</param>
		/// <param name="slotId">the unique identifier for the targeted Slot.</param>
		String SlotText(RingCommunicationData rcData, Guid slotId);

		/// <summary>Should return a String with the MMUnitDescription for the given <paramref name="mmUnitId" />.</summary>
		/// <param name="rcData">All Data Context</param>
		/// <param name="mmUnitId">the unique identifier for the targeted Slot.</param>
		String MMUnitText(RingCommunicationData rcData, Guid mmUnitId);

		#endregion
		}

	public class RingCommunicationData
		{
		public enum RcDataEnum
			{
			DataBaseInstance
			}
		public Dictionary<String, Object> VariableData { get; } = new Dictionary<String, Object>();

		public void Clear()
			{
			if (VariableData.ContainsKey(nameof(RcDataEnum.DataBaseInstance)))
				{
				VariableData[nameof(RcDataEnum.DataBaseInstance)] = null;
				VariableData.Remove(nameof(RcDataEnum.DataBaseInstance));
				}
			}

		}
	}