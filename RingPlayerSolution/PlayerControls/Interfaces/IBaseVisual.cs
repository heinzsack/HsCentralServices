using System;
using System.Windows;
using System.Windows.Media;






namespace PlayerControls.Interfaces
	{
	public interface IBaseVisual
		{
		/// <summary>
		///     RelativePositioning is to base 100. Each value is the percentage of the distance to the outer box which could be an
		///     <see cref="IPage" />. The percentage is then transformed into the
		///     <see cref="IPage" />
		///     metric.
		///     <example>
		///         if the container is in an aspect ratio of 16:9 and the margin is 0,0,0,0 then the resulting box is in aspect
		///         ratio 16:9 or 1920x1080p.
		///         <para>
		///             if the container is in aspect ratio of 16:9 and size 1920:1080 and the margin equals 25,25,25,25 then the
		///             resulting box equals 960x540p and of an aspect ratio of 16:9
		///         </para>
		///     </example>
		/// </summary>
		Thickness IRelativePositioning { get; }
		Color IBackground { get; }
		Color IBorderColor { get; }
		Thickness IBorderThickness { get; }
		double IRotation { get; }


		int ISortOrder { get; }
		}
	}