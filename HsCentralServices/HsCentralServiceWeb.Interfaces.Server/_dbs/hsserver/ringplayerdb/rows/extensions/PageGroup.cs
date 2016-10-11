using System;
using System.Linq;
using System.Windows;
using PlayerControls.Interfaces;






//using DbEntitiesPlayer.hsserver.ringplayerdb.rowinterfaces;

namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows
	{
	partial class PageGroup
		{

		public double DurationInSeconds => Pages.Sum(x => x.ExpectedDuration.GetValueOrDefault(0));
		public new void Delete()
			{
			foreach (Page page in Pages)
				{
				page.Delete();
				}

			DataContext.RingPlayerDb.AcceptChanges();
			base.Delete();
			}


		public IDuratedPage[] GetDuratedPages()
			{
			return Pages.Select(
				page => new DuratedPage(page, new Duration(TimeSpan.FromSeconds(page.ExpectedDuration.GetValueOrDefault(4))))).OfType<IDuratedPage>().ToArray();
			}

		private class DuratedPage : IDuratedPage
			{
			public DuratedPage(IPage page, Duration duration)
				{
				IPage = page;
				IDuration = duration;
				}

			public IPage IPage { get; }
			public Duration IDuration { get; }
			}
		}
	}
