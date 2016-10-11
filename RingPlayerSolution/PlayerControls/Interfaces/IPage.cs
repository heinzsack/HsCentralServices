using System;
using System.Collections.Generic;
using PlayerControls.Interfaces.Transistions;






namespace PlayerControls.Interfaces
	{
	/// <summary>
	///     The dynamic visual container is used to full fill the outer container without preserving the aspect ratio.
	/// </summary>
	public interface IPage : IBaseVisual
		{
		bool IHasFixedRatio { get; }

		/// <summary>
		///     could be 16 when <see cref="IRatioY" /> is 9 to make a 16:9 frame.
		/// </summary>
		double IRatioX { get; }

		/// <summary>
		///     could be 9 when <see cref="IRatioX" /> is 16 to make a 16:9 frame.
		/// </summary>
		double IRatioY { get; }

		/// <summary>
		///     can contain <see cref="IPage" /> or <see cref="ITextVisual" /> or
		///     <see cref="IImageVisual" /> or
		///     <see cref="IVideoVisual" />.
		/// </summary>
		IEnumerable<IBaseVisual> IChildren { get; }

		IEnumerable<ITransition> ITransitions { get; }
		}
	}