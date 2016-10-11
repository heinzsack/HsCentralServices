// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global.transmission.clientIdentification.interfaces;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.dataset;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;






namespace HsCentralServiceWeb._sys.services.ringdistribution.storage
{
	public class RingDistributionStorageEntitys
	{
		private static readonly Regex ExtractRingIndexRegex = new Regex("[0-9]+");
		readonly RingDistributionStoragePaths Paths = Sys.Services.RingDistribution.Storage.Paths;


		public RingMetaData Get(ICsClientInfoComputer computer, int ringId)
		{
			return LoadRingFromFile(Paths.RingFilePath(computer, ringId));
		}

		public RingMetaData Get_CurrentPlaying(ICsClientInfoComputer computer, int ringId)
		{
			return LoadRingFromFile(Paths.PlayingRingFilePath(computer, ringId));
		}

		public void Store(ICsClientInfoComputer computer, RingMetaData ring)
		{
			var ringFile = Paths.RingFilePath(computer, ring.Id);
			ring.DataSet.SaveAs_SerializedBinary(ringFile);
			//TODO if, based on any reason, if Ring files with hiher numbers exist in LRU, the actally created Ring will be destroyed
			var files = ringFile.Directory.GetFiles($"*{Paths.RingExtension}");
			if (files.Length > Sys.Data.CentralService.WebConfigurations.RingDistribution.MaxStoredRingsPerComputer)
			{
				var orderedFiles = files.OrderBy(x => Convert.ToInt32(ExtractRingIndexRegex.Match(x.Name).Value)).ToArray();
				for (var i = 0; i < files.Length - Sys.Data.CentralService.WebConfigurations.RingDistribution.MaxStoredRingsPerComputer; i++)
				{
					orderedFiles[i].Delete();
				}
			}
		}

		public void Store_AsCurrentPlaying(ICsClientInfoComputer computer, RingMetaData ring)
		{
			var ringFile = Paths.PlayingRingFilePath(computer, ring.Id);
			if (ringFile.Directory.Exists)
			{
				var files = ringFile.Directory.GetFiles($"*{computer.Id}*{Paths.RingExtension}");
				foreach (var fileInfo in files)
				{
					fileInfo.Delete();
				}
			}
			ring.DataSet.SaveAs_SerializedBinary(ringFile);

		}

		private RingMetaData LoadRingFromFile(FileInfo fi)
		{
			if (!fi.Exists)
				return null;
			try
			{
				var playerDb = fi.LoadAs_Object_From_SerializedBinary<RingPlayerDb>();
				playerDb.SetHasBeenLoaded();
				playerDb.Images.StreamRequested += image => Sys.Services.RingDistribution.RingManager.GetImageStream(Sys.Server, image.FileIdentifier);
				playerDb.Videos.FileRequested += video => Sys.Services.RingDistribution.RingManager.GetVideoFilePath(Sys.Server, video.FileIdentifier).FullName;

				if (playerDb.RingMetaDatas.Rows.Count == 0)
					return null;

				return playerDb.RingMetaDatas[0];
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}