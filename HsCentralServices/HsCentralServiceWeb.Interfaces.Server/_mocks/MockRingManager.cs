// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.IO;
using System.Linq;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global;
using CsWpfBase.Global.os.functions.knownfolders;
using HsCentralServiceWebInterfacesServer.ringDistribution;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.dataset;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;






namespace HsCentralServiceWebInterfacesServer._mocks
{
	public class MockRingManager : IRingManager
	{
		#region Overrides/Interfaces

		/// <summary>Initializes the database, and other tools for further use.</summary>
		/// <param name="serverContext">The current active server context.</param>
		public void Initialize(IServer serverContext)
		{
		}

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
		public void Generate(IServer serverContext, string computerName, RingMetaData ring)
		{
			new DummyGenerator(ring).Do();
		}

		public void Update(IServer serverContext, string computerName, RingMetaData ring)
		{
			throw new NotImplementedException();
		}

		public PageGroup GeneratePageGroup(IServer serverContext, Guid mmUnitId, RingMetaData ring)
		{
			throw new NotImplementedException();
		}

		/// <summary>Should return an always valid file path for the given <paramref name="id" />.</summary>
		/// <param name="serverContext">The current active server context.</param>
		/// <param name="id">the unique identifier for the targeted image.</param>
		public FileInfo GetImageFilePath(IServer serverContext, Guid id)
		{
			
			var files = new DirectoryInfo(CsGlobal.Os.Functions.KnownFolder.GetPath(KnownFolder.Pictures)).GetFiles("*.jpg", SearchOption.AllDirectories);
			return files[id.ToByteArray().Aggregate((b, b1) => (byte)(b + b1)) % files.Length];
		}

		/// <summary>Should return an always valid file path for the given <paramref name="id" />.</summary>
		/// <param name="serverContext">The current active server context.</param>
		/// <param name="id">the unique identifier for the targeted image.</param>
		public Stream GetImageStream(IServer serverContext, Guid id)
		{
			return null;
		}

		/// <summary>Should return an always valid file path for the given <paramref name="id" />.</summary>
		/// <param name="serverContext">The current active server context.</param>
		/// <param name="id">the unique identifier for the targeted video.</param>
		public FileInfo GetVideoFilePath(IServer serverContext, Guid id)
		{
			return new FileInfo(@"C:\Users\chris\Desktop\urlaub\GOPR2525.MP4");
		}
		#endregion


		public class DummyGenerator
		{
			private int ImageId { get; set; } = 0;

			public DummyGenerator(RingMetaData ring)
			{
				Target = ring;
			}

			public RingMetaData Target { get; set; }
			public RingPlayerDb Db => Target.DataSet;
			public PageGroup PageGroup { get; set; }
			public Page Page { get; set; }

			public void Do()
			{
				GenerateGroup();
				GeneratePageSchedules();
			}

			private void GeneratePageSchedules()
			{
				var pageGroupScheduleId = new Guid();
				var currentTime = DateTime.Now.StartOfDay();
				for (var i = 0; i < 5700; i++)
				{
					if (i%5 == 0)
						pageGroupScheduleId = Guid.NewGuid();

					var pageSchedule = Db.PageSchedules.NewRow();
					pageSchedule.RingMetaData = Target;
					GenerateNewPage();
					pageSchedule.Page = Page;
					pageSchedule.PageGroupScheduleId = pageGroupScheduleId;
					pageSchedule.SlotId = Guid.NewGuid();
					pageSchedule.StartTime = currentTime = currentTime.AddSeconds(15);
					pageSchedule.AddToTable();
				}
			}

			private void GenerateNewPage()
			{
				Page = Db.Pages.NewRow();
				Page.PageGroup = PageGroup;
				Page.AddToTable();
				GenerateImageForPage(Page);
			}

			private void GenerateGroup()
			{
				PageGroup = Db.PageGroups.NewRow();
				PageGroup.Name = "Beitrag1";
				PageGroup.AddToTable();
			}

			private void GenerateImageForPage(Page p)
			{
				ImageId++;
				var image = Db.Images.NewRow();
				image.Page = p;
				image.FileIdentifier = Guid.Parse($"D0091A44-4F83-4DCC-BC1E-{(ImageId%20):D12}");
				image.Extension = ".jpg";
				image.AddToTable();
			}
		}
	}
}