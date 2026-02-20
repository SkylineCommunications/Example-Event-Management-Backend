namespace Skyline.DataMiner.Utils.Examples.EventManagement.ApiHelpers
{
	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.SDM;
	using Skyline.DataMiner.Utils.Examples.EventManagement.Models;

	/// <summary>
	/// Provides an interface for interacting with event-related API helpers.
	/// </summary>
	public interface IEventApiHelper
	{
		/// <summary>
		/// Gets the connection instance.
		/// </summary>
		IConnection Connection { get; }

		/// <summary>
		/// Gets the repository for managing events.
		/// </summary>
		IBulkRepository<Event> Events { get; }
	}
}
