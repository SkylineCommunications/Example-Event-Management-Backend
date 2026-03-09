/*
***********************************************
*  Copyright (c), Skyline Communications NV.  *
***********************************************

Revision History:

DATE		VERSION		AUTHOR			COMMENTS

12/02/2026	1.0.0.1		TVD, Skyline	Initial version
****************************************************************************
*/

using System;
using System.IO;

using EventManagement.Installer.DOM;

using Skyline.AppInstaller;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.AppPackages;
using Skyline.DataMiner.Utils.SecureCoding.SecureIO;

/// <summary>
/// DataMiner Script Class.
/// </summary>
internal class Script
{
	/// <summary>
	/// The script entry point.
	/// </summary>
	/// <param name="engine">Provides access to the Automation engine.</param>
	/// <param name="context">Provides access to the installation context.</param>
	[AutomationEntryPoint(AutomationEntryPointType.Types.InstallAppPackage)]
	public void Install(IEngine engine, AppInstallContext context)
	{
		try
		{
			engine.Timeout = new TimeSpan(0, 10, 0);
			engine.GenerateInformation("Starting installation");
			var installer = new AppInstaller(Engine.SLNetRaw, context);
			if (!IsSdmInstalled(installer))
			{
				installer.Log($"Prerequisite check failed: You need to install SDM first.");
				engine.ExitFail($"Prerequisite check failed: You need to install SDM first.");
				return;
			}

			installer.InstallDefaultContent();

			var domInstaller = new DomInstaller(engine.GetUserConnection(), installer.Log);
			domInstaller.InstallDefaultContent();
		}
		catch (Exception e)
		{
			engine.ExitFail($"Exception encountered during installation: {e}");
		}
	}

	private static bool IsSdmInstalled(AppInstaller installer)
	{
		// Check if SDM is installed
		var solutionLibrariesFolder = @"C:\Skyline DataMiner\ProtocolScripts\DllImport\SolutionLibraries";
		var devPackFolder = SecurePath.ConstructSecurePathWithSubDirectories(solutionLibrariesFolder, "SDM.Abstractions");
		var devPackPath = SecurePath.ConstructSecurePathWithSubDirectories(devPackFolder, "Skyline.DataMiner.Dev.Utils.SDM.Abstractions.dll");

		var result = File.Exists(devPackPath);
		if (!result)
		{
			installer.Log($"Prerequisite check failed: You need to install SDM first.");
		}

		return result;
	}
}
