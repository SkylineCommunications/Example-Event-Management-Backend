namespace Skyline.DataMiner.Learning.EventManagement.ApiHelpers
{
	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.SDM;
	using Skyline.DataMiner.Learning.EventManagement.Models;

	/// <summary>
	/// Provides helper methods and repositories for managing events through the DataMiner API.
	/// </summary>
	public class EventApiHelper : IEventApiHelper
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EventApiHelper"/> class. 
		/// </summary>
		/// <param name="connection">The connection instance.</param>
		public EventApiHelper(IConnection connection)
		{
			Connection = connection;

			Events = new EventDomRepository(connection);
		}

		/// <inheritdoc />
		public IConnection Connection { get; }

		/// <inheritdoc />
		public IBulkRepository<Event> Events { get; }
	}
}
