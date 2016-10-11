
// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-17</date>

using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsWpfBase.Global.transmission.clientIdentification;
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
				RemoteInstance remoteInstance = Sys.Data.CentralService.RemoteInstances.FindOrLoad(id);
				remoteInstance.ThrowNotFound_If_Null($"Es exestiert keine remoteInstance mit der ID = '{id}'");

				RingMetaData ring = Sys.Services.RingDistribution.Generate.For(remoteInstance);
				return new EmptyResult();
				}
			}
		public ActionResult LoadInstanceArgs(Guid id)
		{
			lock(Sys.Data)
			{
				RemoteInstance remoteInstance = Sys.Data.CentralService.RemoteInstances.FindOrLoad(id);
				remoteInstance.ThrowNotFound_If_Null($"Es exestiert keine remoteInstance mit der ID = '{id}'");

				Sys.Hubs.RingDistribution.OnPlayerDataRequested(remoteInstance, new PlayerDataRequestArgs());
				return new EmptyResult();
			}
		}
		public ActionResult DownloadRing(int ringId)
		{
			CsClientIdentification clientIdentification = CsClientIdentification.Transmission.Get(Request.Headers);
			FileInfo ringPath = Sys.Services.RingDistribution.Storage.Paths.RingFilePath(clientIdentification.Computer, ringId);
			if (!ringPath.Exists)
				throw new HttpException((int)HttpStatusCode.NotFound, $"Der angegebene ring [{ringId}] mit dem FileNamen {ringPath.FullName} konnte beim Computer [{clientIdentification.Computer.Name}] nicht gefunden werden");
			if (ringPath.Length == 0)
				throw new HttpException((int)HttpStatusCode.LengthRequired, $"Der angegebene ring [{ringId}] mit dem FileNamen {ringPath.FullName} hat beim computer [{clientIdentification.Computer.Name}] die Länge 0");

			return new FilePathResult(ringPath.FullName, MimeMapping.GetMimeMapping(ringPath.FullName));
		}

		public ActionResult DownloadImage(Guid imageId)
		{
		lock (Sys.Data)
				{
				Stream stream = Sys.Services.RingDistribution.RingManager.GetImageStream(Sys.Server, imageId);
				stream.ThrowNotFound_If_Null($"Das Bild mit der Id [{imageId}] konnte nicht gefunden werden");
				return new FileStreamResult(stream, "stream");
				}
		}

		public ActionResult DownloadVideo(Guid videoId)
		{
			string fileName = Sys.Services.RingDistribution.RingManager.GetVideoFilePath(Sys.Server, videoId)?.FullName;
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
	}
}