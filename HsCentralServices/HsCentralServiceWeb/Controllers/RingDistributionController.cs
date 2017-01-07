// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-06</date>

using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsWpfBase.Global.remote.clientIdentification;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWeb._sys;
using HsCentralServiceWeb._sys._extensions;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;






namespace HsCentralServiceWeb.Controllers
{
	public class RingDistributionController : Controller
	{

		public ActionResult GenerateRing(Guid id)
		{
			lock (Sys.Data)
			{
				var remoteInstance = Sys.Data.CentralService.RemoteInstances.FindOrLoad(id);
				remoteInstance.ThrowNotFound_If_Null($"Es exestiert keine remoteInstance mit der ID = '{id}'");

				var ring = Sys.Services.RingDistribution.Generate.For(remoteInstance);
				return new EmptyResult();
			}
		}

		public ActionResult LoadInstanceArgs(Guid id)
		{
			lock (Sys.Data)
			{
				var remoteInstance = Sys.Data.CentralService.RemoteInstances.FindOrLoad(id);
				remoteInstance.ThrowNotFound_If_Null($"Es exestiert keine remoteInstance mit der ID = '{id}'");

				Sys.Hubs.RingDistribution.OnPlayerDataRequested(remoteInstance, new PlayerDataRequestArgs());
				return new EmptyResult();
			}
		}

		public ActionResult DownloadRing(int ringId)
		{
			lock (Sys.Data)
			{

				var clientIdentification = CsClientIdentification.Transmission.Get(Request.Headers);
				var ringPath = Sys.Services.RingDistribution.Storage.Paths.RingFilePath(clientIdentification.Computer, ringId);
				if (!ringPath.Exists)
					throw new HttpException((int) HttpStatusCode.NotFound, $"Der angegebene ring [{ringId}] mit dem FileNamen {ringPath.FullName} konnte beim Computer [{clientIdentification.Computer.Name}] nicht gefunden werden");
				if (ringPath.Length == 0)
					throw new HttpException((int) HttpStatusCode.LengthRequired, $"Der angegebene ring [{ringId}] mit dem FileNamen {ringPath.FullName} hat beim computer [{clientIdentification.Computer.Name}] die Länge 0");

				return new FilePathResult(ringPath.FullName, MimeMapping.GetMimeMapping(ringPath.FullName));
			}
		}

		public ActionResult DownloadImage(Guid imageId)
		{
			lock (Sys.Data)
			{
				var stream = Sys.Services.RingDistribution.RingManager.GetImageStream(Sys.Server, imageId);
				if (stream == null)
					stream = Sys.Services.RingDistribution.RingManager.GetImageFilePath(Sys.Server, imageId).Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

				stream.ThrowNotFound_If_Null($"Das Bild mit der Id [{imageId}] konnte nicht gefunden werden");
				return new FileStreamResult(stream, "stream");
			}
		}

		public ActionResult DownloadVideo(Guid videoId)
		{
			var fileName = Sys.Services.RingDistribution.RingManager.GetVideoFilePath(Sys.Server, videoId)?.FullName;
			fileName.ThrowNotFound_If_Null($"Das Video mit der Id [{videoId}] konnte nicht gefunden werden");
			return new FilePathResult(fileName, MimeMapping.GetMimeMapping(fileName));
		}

		public ActionResult Clear()
		{
			lock (Sys.Data)
			{
				return new ContentResult() {Content = "[NOTIMPLEMENTED]"};
			}

		}

		public ActionResult GenerateAll()
		{
			lock (Sys.Data)
			{
				RingMetaData firstRing = null;
				RemoteInstance firstRemoteInstance = null;
				foreach (var centralServiceRemoteInstance in Sys.Hubs.RingDistribution.ConnectedClients)
				{
					var remoteInstance = Sys.Data.CentralService.RemoteInstances.FindOrLoad(centralServiceRemoteInstance.Id);
					remoteInstance.ThrowNotFound_If_Null(
						$"Es exestiert keine remoteInstance mit der ID = '{centralServiceRemoteInstance.Id}'");
					var ring = Sys.Services.RingDistribution.Generate.For(remoteInstance);
					if (firstRing == null)
					{
						firstRing = ring;
						firstRemoteInstance = remoteInstance;
					}
				}
				return RedirectToAction("Service", "Ring");
			}
		}
	}
}