// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.Web;
using System.Web.Mvc;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWeb._sys.data;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.newRingAvailableArgs;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.dataset;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;






namespace HsCentralServiceWeb._sys.services.ringdistribution.generate
{
	public class RingDistributionGenerator
	{
		public RingMetaData For(RemoteInstance centralServiceDbInstance)
		{
			var db = GetRingPlayerDbDataSet();

			centralServiceDbInstance.RingPlayerManagement.LatestGeneratedRingId = (centralServiceDbInstance.RingPlayerManagement.LatestGeneratedRingId ?? 0) + 1;

			var ringMetaData = db.RingMetaDatas.NewRow();
			ringMetaData.Id = centralServiceDbInstance.RingPlayerManagement.LatestGeneratedRingId.Value;
			ringMetaData.TargetDate = DateTime.Now;
			ringMetaData.SenderId = Guid.Empty;
			ringMetaData.CreationDate = DateTime.Now;
			ringMetaData.Occasion = "created on Central Web request";
			ringMetaData.AddToTable();

			Sys.Services.RingDistribution.RingManager?.Generate(Sys.Server,centralServiceDbInstance.RemoteUser.RemoteComputer.Name, ringMetaData);

			ringMetaData.DataSet.AcceptChanges();

			//Store Ring
			Sys.Services.RingDistribution.Storage.Ring.Store
				(centralServiceDbInstance.RemoteUser.RemoteComputer, ringMetaData);

			var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
			Sys.Hubs.RingDistribution.OnNewRingAvailable(centralServiceDbInstance, new NewRingAvailableArgs
				{
					RingId = ringMetaData.Id,
					DownloadUrl = url.Action("DownloadRing", "RingDistribution", new {ringId = ringMetaData.Id}, HttpContext.Current.Request.Url.Scheme),
					ImageDownloadUrl = url.Action("DownloadImage", "RingDistribution", new {imageId = "REPLACEMENT"}, HttpContext.Current.Request.Url.Scheme),
					VideoDownloadUrl = url.Action("DownloadVideo", "RingDistribution", new {videoId = "REPLACEMENT"}, HttpContext.Current.Request.Url.Scheme),
					ImageVideoReplacementString = "REPLACEMENT",
				});

			centralServiceDbInstance.DataSet.SaveAnabolic();
			centralServiceDbInstance.DataSet.AcceptChanges();

			return ringMetaData;
		}

		public RingMetaData ForAny()
		{
			var db = GetRingPlayerDbDataSet();

			var ring = db.RingMetaDatas.NewRow();
			ring.Id = 0;
			ring.TargetDate = DateTime.Now;
			ring.SenderId = Guid.Empty;
			ring.CreationDate = DateTime.Now;
			ring.Occasion = "any db";
			ring.AddToTable();
			ring.DataSet.AcceptChanges();

			ring.DataSet.Images.StreamRequested += image => Sys.Services.RingDistribution.RingManager.GetImageStream(Sys.Server, image.FileIdentifier);
			ring.DataSet.Videos.FileRequested += video => Sys.Services.RingDistribution.RingManager.GetVideoFilePath(Sys.Server, video.FileIdentifier).FullName;
			return ring;
		}

		private RingPlayerDb GetRingPlayerDbDataSet()
		{
			var ringPlayerDb = new RingPlayerDb();
			ringPlayerDb.Set_DbProxy(new Data.HsServerDirectConnector {Catalog = RingPlayerDb.NativeName});
			ringPlayerDb.LoadConstraints();
			ringPlayerDb.Set_DbProxy(null);
			ringPlayerDb.SetHasBeenLoaded();
			return ringPlayerDb;
		}
	}




}