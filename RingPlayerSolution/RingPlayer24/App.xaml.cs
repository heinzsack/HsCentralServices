using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global;

namespace RingPlayer24
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
		{

		public enum PlayerOption
			{
			UnDefined,
			DynamicScreen,
			FullScreen,
			TopRightScreen
			}

		public List<PlayerOption> PlayerOptions { get; } = new List<PlayerOption>();
		MainWindow mainWindowToUse = null;

		public String ComputerName => CsGlobal.Os.Info.ComputerName;
		private void App_OnStartup(object sender, StartupEventArgs e)
			{
			Application.Current.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException;
			if (IAmActiveBefore())
				{
				this.Shutdown();
				return;
				}

			mainWindowToUse = new MainWindow();

			if (e.Args.Length != 0)
				{
				int argIndex = 0;
				foreach (string eArg in e.Args)
					{
					PlayerOption playerOption = PlayerOption.UnDefined;
					if (Enum.TryParse(eArg, true, out playerOption))
						PlayerOptions.Add(playerOption);
					}


				if (PlayerOptions.Contains(PlayerOption.FullScreen))
					{
					mainWindowToUse.WindowStyle = WindowStyle.None;
					mainWindowToUse.WindowState = WindowState.Maximized;
					}
				else if (PlayerOptions.Contains(PlayerOption.TopRightScreen))
					{
					mainWindowToUse.WindowStyle = WindowStyle.None;
					if ((SystemParameters.PrimaryScreenHeight <= 1080)
						&& (SystemParameters.PrimaryScreenWidth <= 1920))
						{
						mainWindowToUse.Width = SystemParameters.PrimaryScreenWidth * 0.75;
						mainWindowToUse.Height = SystemParameters.PrimaryScreenHeight * 0.75;
						mainWindowToUse.Left = SystemParameters.PrimaryScreenWidth * 0.25;
						mainWindowToUse.Top = 0;
						}
					else
						{
						mainWindowToUse.Width = 1920 * 0.75;
						mainWindowToUse.Height = 1080 * 0.75;
						mainWindowToUse.Left = 1920 * 0.25;
						mainWindowToUse.Top = 0;
						}
					}
				else if (PlayerOptions.Contains(PlayerOption.DynamicScreen))
					{
					mainWindowToUse.WindowStyle = WindowStyle.SingleBorderWindow;
					mainWindowToUse.WindowState = WindowState.Normal;
					}
				else
					{
					mainWindowToUse.WindowStyle = WindowStyle.SingleBorderWindow;
					mainWindowToUse.WindowState = WindowState.Normal;
					}
				}
			else
				{
				mainWindowToUse.WindowStyle = WindowStyle.SingleBorderWindow;
				mainWindowToUse.WindowState = WindowState.Normal;
				}


			mainWindowToUse.Show();
			}

		private void CurrentOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
			{
#if (DEBUG)
#else
			args.Exception?.MostInner()?.ToString().SaveAs_Utf8String(new FileInfo($"{DateTime.Now:MM.dd HH.mm.ss}Exception.txt").In_Desktop_Directory());
			CsGlobal.App.Exit();
			args.Handled = true;
#endif
			}

		public static int HowOftenIsThisProcessActive(String ProcessName)
			{
			return Process.GetProcessesByName(ProcessName).Length;
			}

		public static bool IAmActiveBefore()
			{
			String MyProcessName = Process.GetCurrentProcess().ProcessName;
			int NumberOfRunningInstances = HowOftenIsThisProcessActive(MyProcessName);
			if (NumberOfRunningInstances > 1)
				return true;
			return false;
			}


		}
	}
