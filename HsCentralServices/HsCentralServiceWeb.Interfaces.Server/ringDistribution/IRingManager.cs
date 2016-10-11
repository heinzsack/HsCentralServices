// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.IO;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;






namespace HsCentralServiceWebInterfacesServer.ringDistribution
{
	/// <summary>Used on the central service for filling and updateing rings which should be played on a player.</summary>
	public interface IRingManager
	{
		#region Abstract
		/// <summary>Initializes the database, and other tools for further use.</summary>
		/// <param name="serverContext">The current active server context.</param>
		void Initialize(IServer serverContext);

		/// <summary>
		///     Generates a complete new ring into the provided <paramref name="ring" /> dataset. This should produce a complete 24 hour active ring which has no
		///     other logic then playing the right things at the right time, independet of the past.
		/// </summary>
		/// <param name="serverContext">The current active server context.</param>
		/// <param name="computerName">The name of the computer this ring is generated for.</param>
		/// <param name="ring">The target ring where all the generated data should be inserted at.</param>
		/// <remarks>
		///     Things which need to be done:
		///     <para>Set <see cref="RingMetaData.SenderId" /> to the targeting sender id.</para>
		///     <para>Generate <see cref="PageGroup" />s inside the database.</para>
		///     <para>
		///         Generate <see cref="Page" />s with the associated content (<see cref="Text" />, <see cref="Image" /> <see cref="Video" />,
		///         <see cref="DoubleTransition" />).
		///     </para>
		///     <para>
		///         Generate <see cref="PageSchedule" />s. <see cref="PageSchedule" />s in sequence which belongs to the same <see cref="PageGroup" /> needs to
		///         have the same <see cref="PageSchedule.PageGroupScheduleId" />.
		///     </para>
		/// </remarks>
		void Generate(IServer serverContext, string computerName, RingMetaData ring);

		void Update(IServer serverContext, string computerName, RingMetaData ring);

		PageGroup GeneratePageGroup(IServer serverContext, Guid mmUnitId, RingMetaData ring);

		/// <summary>Should return an always valid file path for the given <paramref name="id" />.</summary>
		/// <param name="serverContext">The current active server context.</param>
		/// <param name="id">the unique identifier for the targeted image.</param>
		FileInfo GetImageFilePath(IServer serverContext, Guid id);

		/// <summary>Should return an always valid file path for the given <paramref name="id" />.</summary>
		/// <param name="serverContext">The current active server context.</param>
		/// <param name="id">the unique identifier for the targeted image.</param>
		Stream GetImageStream(IServer serverContext, Guid id);

		/// <summary>Should return an always valid file path for the given <paramref name="id" />.</summary>
		/// <param name="serverContext">The current active server context.</param>
		/// <param name="id">the unique identifier for the targeted video.</param>
		FileInfo GetVideoFilePath(IServer serverContext, Guid id);
		#endregion
	}
}