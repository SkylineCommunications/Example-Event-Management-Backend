namespace Skyline.DataMiner.Utils.Examples.EventManager.ApiHelpers
{
    using Skyline.DataMiner.Net;
    using Skyline.DataMiner.SDM;
    using Skyline.DataMiner.Utils.Examples.EventManager.Models;

    public class EventApiHelper : IEventApiHelper
    {
        private readonly IBulkRepository<Event> _Events;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventApiHelper"/> class. 
        /// </summary>
        /// <param name="connection">The connection instance.</param>
        public EventApiHelper(IConnection connection)
        {
            Connection = connection;

            _Events = new EventDomRepository(connection);
        }

        /// <summary>
        /// Gets the connection instance.
        /// </summary>
        public IConnection Connection { get; }

        /// <summary>
        /// Gets the repository for managing events.
        /// </summary>
        public IBulkRepository<Models.Event> Events { get { return _Events; } }
    }
}
