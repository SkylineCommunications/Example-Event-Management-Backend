namespace EventInstallBackEnd.DOM
{
	using System;
	using System.Linq;
	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
	using Skyline.DataMiner.Net.Apps.Modules;
	using Skyline.DataMiner.Net.ManagerStore;
	using Skyline.DataMiner.Net.Messages.SLDataGateway;
	using Skyline.DataMiner.Utils.DOM.Builders;
    using Skyline.DataMiner.Utils.Examples.EventManager.Models;

    public partial class DomInstaller
		{
			private readonly IConnection _connection;
			private readonly Action<string> _logMethod;

			public DomInstaller(IConnection connection, Action<string> logMethod = null)
			{
				_connection = connection;
				_logMethod = logMethod;
			}

			public void InstallDefaultContent()
			{
				Log("Installation for Event DOM module started...");

				var moduleHelper = new ModuleSettingsHelper(_connection.HandleMessages);
				var moduleExist = moduleHelper.ModuleSettings.Count(ModuleSettingsExposers.ModuleId.Equal(EventDomMapper.ModuleId)) == 0;
				if (!moduleExist)
				{
					Log("Installing Module Settings...");
				}
				else
				{
					Log("Updating Module Settings...");
				}

				var module = new DomModuleBuilder()
					.WithModuleId(EventDomMapper.ModuleId)
					.WithInformationEvents(false)
					.WithHistory(true)
					.Build();
				Import(moduleHelper.ModuleSettings, ModuleSettingsExposers.ModuleId.Equal(EventDomMapper.ModuleId), module);

				if (!moduleExist)
				{
					Log("Installed Event Module Settings");
				}
				else
				{
					Log("Updated Event Module Settings");
				}

				var domHelper = new DomHelper(_connection.HandleMessages, EventDomMapper.ModuleId);
				InstallEvent(domHelper);
			}

			private void Log(string message)
			{
				_logMethod?.Invoke($"[DoD.Installer.Event]: {message}");
			}

			private void Import<T>(ICrudHelperComponent<T> crudHelperComponent, FilterElement<T> equalityFilter, T dataType)
				where T : DataType
			{
				bool exists = crudHelperComponent.Read(equalityFilter).Any();

				if (exists)
				{
					crudHelperComponent.Update(dataType);
				}
				else
				{
					crudHelperComponent.Create(dataType);
				}
			}
		}
}
