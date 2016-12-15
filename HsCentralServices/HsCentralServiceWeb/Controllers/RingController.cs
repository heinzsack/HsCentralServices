// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using HsCentralServiceWeb.Models.RingController;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWeb._sys;
using HsCentralServiceWeb._sys._extensions;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;






//using RingPlayerDbEntities.hsserver.ringplayerdb.rows;

namespace HsCentralServiceWeb.Controllers
{
	public class RingController : Controller
	{
	public ActionResult Service()
		{
		lock (Sys.Data)
			{
			return View();
			}
		}


		public ActionResult Partial_ConnectedClients()
		{
			lock(Sys.Data)
			{
				return PartialView("controls/List_RingDistributionConnectedClients");
			}
		}

		public ActionResult Partial_UnConnectedClients()
			{
			lock (Sys.Data)
				{
				return PartialView("controls/List_RingDistributionUnConnectedClients");
				}
			}
		public ActionResult View(Guid remoteInstanceId, int ringId)
		{
			lock (Sys.Data)
			{
				RemoteInstance remoteInstance = Sys.Data.CentralService.RemoteInstances.FindOrLoad(remoteInstanceId);
				remoteInstance.ThrowNotFound_If_Null($"Die angegebene {nameof(RemoteInstance)} [{remoteInstanceId}] konnte nicht gefunden werden.");

				RingMetaData ringMetaData = Sys.Services.RingDistribution.Storage
									.Ring.Get(remoteInstance.RemoteUser.RemoteComputer, ringId);
				ringMetaData.ThrowNotFound_If_Null($"Der angegebene Ring im Computer" +
													$"[{remoteInstance.RemoteUser.RemoteComputer.Name}] konnte nicht gefunden werden.");

				return View("View", new ViewModel(remoteInstance, ringMetaData));
			}
		}


		public ActionResult ViewEntry(Guid remoteInstanceId, int ringId, Guid pageGroupId)
		{
			lock (Sys.Data)
			{
				RemoteInstance remoteInstance = Sys.Data.CentralService.RemoteInstances
													.FindOrLoad(remoteInstanceId);
				remoteInstance.ThrowNotFound_If_Null($"Die angegebene {nameof(RemoteInstance)} [{remoteInstanceId}] konnte nicht gefunden werden.");

				RingMetaData ringMetaData = Sys.Services.RingDistribution
									.Storage.Ring.Get(remoteInstance.RemoteUser.RemoteComputer, ringId);
				ringMetaData.ThrowNotFound_If_Null($"Der angegebene Ring im Computer" +
													$"[{remoteInstance.RemoteUser.RemoteComputer.Name}] " +
													$"konnte nicht gefunden werden.");

				PageGroup pageGroup = ringMetaData.DataSet.PageGroups.Find(pageGroupId);
				ringMetaData.ThrowNotFound_If_Null($"Die angegebene {nameof(PageGroup)}[{pageGroupId}] im Ring[{ringId}] im Computer[{remoteInstance.RemoteUser.RemoteComputer.Name}] konnte nicht gefunden werden.");
				Sys.Services.RingDistribution.RingManager?.GeneratePageGroup(Sys.Server, pageGroupId, ringMetaData);
				return View("PageGroup", new PageGroupViewModel(remoteInstance,ringMetaData, pageGroup));
			}
		}

		public ActionResult Download(Guid remoteInstanceId, int ringId)
		{
			lock (Sys.Data)
			{

				RemoteInstance remoteInstance = Sys.Data.CentralService.RemoteInstances.FindOrLoad(remoteInstanceId);
				remoteInstance.ThrowNotFound_If_Null($"Die angegebene {nameof(RemoteInstance)} " + $"[{remoteInstanceId}] konnte nicht gefunden werden.");

				FileInfo ringFilePath = Sys.Services.RingDistribution.Storage.Paths.RingFilePath(remoteInstance.RemoteUser.RemoteComputer, ringId);
				if (!ringFilePath.Exists)
					throw new FileNotFoundException($"der RingFile '{ringFilePath.FullName}'" + $" existiert nicht");
				return new FilePathResult(ringFilePath.FullName, MimeMapping.GetMimeMapping(ringFilePath.FullName))
				{
					FileDownloadName = $"{remoteInstance.RemoteUser.RemoteComputer.Name.ToUpper()} __ {ringId}.Ring24"
				};
			}
		}

		public ActionResult ViewMmUnit(Guid id)
		{
			lock(Sys.Data)
			{
				//MMUnit mmUnit = Sys.Data.Multimedia.MMUnits.FindOrLoad(id);
				//mmUnit.ThrowNotFound_If_Null($"Die angegebene {nameof(MMUnit)}[{id}] " +
				//			$"konnte nicht gefunden werden.");
				//Todo in search for MVC Startup Error		one of the last changes		
				RingMetaData ringMetaData = Sys.Services.RingDistribution.Generate.ForAny();
				PageGroup pageGroup = Sys.Services.RingDistribution.RingManager.GeneratePageGroup(Sys.Server, id, ringMetaData);
				return View("AnyPageGroup", new DbPageGroupViewModel(pageGroup));
			}
		}
	}
}