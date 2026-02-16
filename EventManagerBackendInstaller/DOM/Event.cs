namespace EventInstallBackEnd.DOM
{
	using System;
	using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
	using Skyline.DataMiner.Net.GenericEnums;
	using Skyline.DataMiner.Net.Messages.SLDataGateway;
	using Skyline.DataMiner.Net.Sections;
    using Skyline.DataMiner.Utils.DOM.Builders;
    using Skyline.DataMiner.Utils.Examples.EventManager.Models;

    public partial class DomInstaller
	{
		private void InstallEventPropertiesSection(DomHelper helper)
		{
			var section = new SectionDefinitionBuilder()
				.WithID(EventDomMapper.EventProperties.SectionDefinitionId)
				.WithName(nameof(EventDomMapper.EventProperties))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(EventDomMapper.EventProperties.Name)
					.WithName(nameof(EventDomMapper.EventProperties.Name))
					.WithType(typeof(string))
					.WithIsOptional(true)
					.WithTooltip("The name of the event"))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(EventDomMapper.EventProperties.Description)
					.WithName(nameof(EventDomMapper.EventProperties.Description))
					.WithType(typeof(string))
					.WithIsOptional(true)
					.WithTooltip("The description of the event"))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(EventDomMapper.EventProperties.Start)
					.WithName(nameof(EventDomMapper.EventProperties.Start))
					.WithType(typeof(DateTime))
					.WithIsOptional(true)
					.WithTooltip("The start of the event"))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(EventDomMapper.EventProperties.End)
					.WithName(nameof(EventDomMapper.EventProperties.End))
					.WithType(typeof(DateTime))
					.WithIsOptional(true)
					.WithTooltip("The end of the event"))
				.AddFieldDescriptor(new GenericEnumFieldDescriptorBuilder()
 					.WithID(EventDomMapper.EventProperties.Type)
 					.WithName(nameof(EventDomMapper.EventProperties.Type))
 					.WithIsOptional(true)
 					.WithTooltip("The Type of the event")
 					.WithEnumType(GenericEnumFieldDescriptorBuilder.EnumType.Int)
 					.AddEnumValue(new GenericEnumEntry<int>("Basic", 0))
 					.AddEnumValue(new GenericEnumEntry<int>("Pro", 1))
 					.AddEnumValue(new GenericEnumEntry<int>("Advanced", 2)))
				.AddFieldDescriptor(new GenericEnumFieldDescriptorBuilder()
 					.WithID(EventDomMapper.EventProperties.Priority)
 					.WithName(nameof(EventDomMapper.EventProperties.Priority))
 					.WithIsOptional(true)
 					.WithTooltip("The priority of the event")
 					.WithEnumType(GenericEnumFieldDescriptorBuilder.EnumType.Int)
 					.AddEnumValue(new GenericEnumEntry<int>("Low", 0))
 					.AddEnumValue(new GenericEnumEntry<int>("Medium", 1))
 					.AddEnumValue(new GenericEnumEntry<int>("High", 2)))
				.Build();

			Import(helper.SectionDefinitions,SectionDefinitionExposers.ID.Equal(EventDomMapper.EventProperties.SectionDefinitionId.Id), section);
		}

		private void InstallAdditionalPackagesSection(DomHelper helper)
		{
			var section = new SectionDefinitionBuilder()
				.WithID(EventDomMapper.Languages.SectionDefinitionId)
				.WithName(nameof(EventDomMapper.Languages))
                .AddFieldDescriptor(new FieldDescriptorBuilder()
                    .WithID(EventDomMapper.Languages.Name)
                    .WithName(nameof(EventDomMapper.Languages.Name))
                    .WithType(typeof(string))
                    .WithIsOptional(true)
                    .WithTooltip("The name of the language"))
                .AddFieldDescriptor(new GenericEnumFieldDescriptorBuilder()
					.WithID(EventDomMapper.Languages.AudioType)
					.WithName(nameof(EventDomMapper.Languages.AudioType))
					.WithIsOptional(true)
					.WithTooltip("The audio type of the language")
					.WithEnumType(GenericEnumFieldDescriptorBuilder.EnumType.Int)
					.AddEnumValue(new GenericEnumEntry<int>("Stereo", 0))
					.AddEnumValue(new GenericEnumEntry<int>("Surround", 1))
					.AddEnumValue(new GenericEnumEntry<int>("Mono", 2)))
                 .AddFieldDescriptor(new FieldDescriptorBuilder()
                    .WithID(EventDomMapper.Languages.CcSupplierCompanyName)
                    .WithName(nameof(EventDomMapper.Languages.CcSupplierCompanyName))
                    .WithType(typeof(string))
                    .WithIsOptional(true)
                    .WithTooltip("The cc supplier company name"))
                .Build();

			Import(helper.SectionDefinitions, SectionDefinitionExposers.ID.Equal(EventDomMapper.Languages.SectionDefinitionId.Id), section);
		}

		private void InstallEventDefinition(DomHelper helper)
		{
			var definition = new DomDefinitionBuilder()
				.WithID(EventDomMapper.DomDefinitionId)
				.WithName("Event")
				.AddSectionDefinitionLink(new Skyline.DataMiner.Net.Apps.Sections.SectionDefinitions.SectionDefinitionLink
				{
					SectionDefinitionID = EventDomMapper.EventProperties.SectionDefinitionId,
					AllowMultipleSections = false,
					IsOptional = false,
					IsSoftDeleted = false,
				})
				.AddSectionDefinitionLink(new Skyline.DataMiner.Net.Apps.Sections.SectionDefinitions.SectionDefinitionLink
				{
					SectionDefinitionID = EventDomMapper.Languages.SectionDefinitionId,
					AllowMultipleSections = true,
					IsOptional = true,
					IsSoftDeleted = false,
				})
				.Build();
				Import(helper.DomDefinitions, DomDefinitionExposers.Id.Equal(EventDomMapper.DomDefinitionId.Id), definition);
		}

		private void InstallEvent(DomHelper helper)
		{
			Log("Installing Event DOM Definition...");
			InstallEventPropertiesSection(helper);
			InstallAdditionalPackagesSection(helper);
			InstallEventDefinition(helper);
			Log("Installed Event DOM Definition.");
		}
	}
}
