using System;
using Newtonsoft.Json;
using PlayerControls.Interfaces.presentation.FrameItems;






namespace PlayerControls._sys.pocos.presentation
{
	[JsonObject(MemberSerialization.OptIn)]
	[Serializable]
	public class PocoFrameVideo : PocoFrameItem, IFrameVideo
	{
		/// <inheritdoc />
		private string _frameItemVideoFilePath;


		#region Overrides/Interfaces
		/// <inheritdoc />
		public string FrameItemVideoFilePath => _frameItemVideoFilePath;

		/// <inheritdoc />
		public void EditorRequestedVideoChange()
		{
			throw new NotImplementedException();
		}
		#endregion


	}
}