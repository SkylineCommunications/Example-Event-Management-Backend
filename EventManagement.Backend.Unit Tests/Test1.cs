namespace EventManagement.Backend.Unit_Tests
{
	using FluentAssertions;

	using Skyline.DataMiner.Net.Messages.SLDataGateway;
	using Skyline.DataMiner.Utils.DOM.UnitTesting;
	using Skyline.DataMiner.Learning.EventManagement.ApiHelpers;
	using Skyline.DataMiner.Learning.EventManagement.Models;

	[TestClass]
	public sealed class RepositoryTests
	{
		[TestMethod]
		public void Create()
		{
			// Arrange
			var messageHandler = new DomSLNetMessageHandler();
			var connection = new DomConnectionMock(messageHandler);
			var helper = new EventApiHelper(connection);

			// Act
			var @event = new Event
			{
				Name = "Test Event",
				Description = "This is a test event.",
				Start = DateTime.Now,
				End = DateTime.Now.AddHours(1),
				Type = EventType.Pro,
				Status = EventStatus.Done,
				Languages =
				[
					new()
					{
						Name = "en",
						AudioType = LanguageAudioType.Mono,
						CcSupplierCompanyName = "Test Company",
					},
					new()
					{
						Name = "nl",
						AudioType = LanguageAudioType.Stereo,
						CcSupplierCompanyName = "Major Company",
					},
					new()
					{
						Name = "fr",
						AudioType = LanguageAudioType.Surround,
						CcSupplierCompanyName = "A Company",
					},
				],
			};

			helper.Events.Create(@event);
			var readEvent = helper.Events.Read(new TRUEFilterElement<Event>()).ToArray();

			// Assert
			readEvent.Should().NotBeNull();
			readEvent.Should().HaveCount(1);
			readEvent[0].Name.Should().Be(@event.Name);
			readEvent[0].Description.Should().Be(@event.Description);
			readEvent[0].Start.Should().Be(@event.Start);
			readEvent[0].End.Should().Be(@event.End);
			readEvent[0].Type.Should().Be(@event.Type);
			readEvent[0].Status.Should().Be(@event.Status);
			readEvent[0].Languages.Should().NotBeNull();
			readEvent[0].Languages.Should().HaveCount(3);
			readEvent[0].Languages[0].Name.Should().Be(@event.Languages[0].Name);
			readEvent[0].Languages[0].AudioType.Should().Be(@event.Languages[0].AudioType);
			readEvent[0].Languages[0].CcSupplierCompanyName.Should().Be(@event.Languages[0].CcSupplierCompanyName);
			readEvent[0].Languages[1].Name.Should().Be(@event.Languages[1].Name);
			readEvent[0].Languages[1].AudioType.Should().Be(@event.Languages[1].AudioType);
			readEvent[0].Languages[1].CcSupplierCompanyName.Should().Be(@event.Languages[1].CcSupplierCompanyName);
			readEvent[0].Languages[2].Name.Should().Be(@event.Languages[2].Name);
			readEvent[0].Languages[2].AudioType.Should().Be(@event.Languages[2].AudioType);
			readEvent[0].Languages[2].CcSupplierCompanyName.Should().Be(@event.Languages[2].CcSupplierCompanyName);
		}
	}
}
