// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.IO;
using System.Linq;
using System.Reflection;
#if CS
//using AddOnRingDistribution.RingManager;
#else
using AddOnRingDistribution.RingManager;
#endif
using CsWpfBase.Ev.Public.Extensions;
using HsCentralServiceWeb._sys.services.ringdistribution.communication;
using HsCentralServiceWeb._sys.services.ringdistribution.generate;
using HsCentralServiceWeb._sys.services.ringdistribution.storage;
using HsCentralServiceWebInterfacesServer.ringDistribution;
using HsCentralServiceWebInterfacesServer._mocks;





namespace HsCentralServiceWeb._sys.services.ringdistribution
{
	public class RingDistribution
	{
		private RingDistributionCommunication _communication;
		private IRingManager _dynamicRingManager;
		private RingDistributionGenerator _generator;
		private string _ringManagerAssemblyHash = "";
		private IRingManager _staticRingManager;
		private RingDistributionStorage _storage;


		private IRingManager DynamicRingManager
		{
			get
			{
				FileInfo extensionFilePath = Sys.Services.RingDistribution.Storage.Paths.GetExtensionFilePath();
				string hash = (extensionFilePath != null) && extensionFilePath.Exists ? extensionFilePath.LoadAs_ByteArray().Sha1Hash().ConvertTo_Base64() : null;
				if ((_dynamicRingManager != null) && !hash.IsNullOrEmpty() && _ringManagerAssemblyHash.Equals(hash))
					return _dynamicRingManager;

				_dynamicRingManager = null;
				_ringManagerAssemblyHash = null;

				if ((extensionFilePath == null) || !extensionFilePath.Exists)
					return null;

				try
				{
					Type[] types = Assembly.LoadFrom(extensionFilePath.FullName).GetTypes();
					Type type = types.FirstOrDefault(typeof(IRingManager).IsAssignableFrom);

					if (type == null)
						return null;
					IRingManager ringManager = _dynamicRingManager = (IRingManager) Activator.CreateInstance(type);
					_ringManagerAssemblyHash = hash;
					return ringManager;
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		public RingDistributionStorage Storage => _storage ?? (_storage = new RingDistributionStorage());
		public RingDistributionGenerator Generate => _generator ?? (_generator = new RingDistributionGenerator());
		public RingDistributionCommunication Communication => _communication ?? (_communication = new RingDistributionCommunication());



		public IRingManager RingManager
		{
			get
			{
				if (DynamicRingManager != null)
					return DynamicRingManager;
				if (_staticRingManager == null)
				{
#if CS
					_staticRingManager = new MockRingManager();
#else
					_staticRingManager = new RingManger();
#endif
					_staticRingManager.Initialize(Sys.Server);
				}

				return _staticRingManager;
			}
			set { _staticRingManager = value; }
		}
	}



}