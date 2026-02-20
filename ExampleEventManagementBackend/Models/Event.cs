namespace Skyline.DataMiner.Utils.Examples.EventManagement.Models
{
	using System;
	using System.Collections.Generic;

	using Skyline.DataMiner.SDM;

	/// <summary>
	/// Represents an event in the event management system.
	/// </summary>
	[GenerateExposers]
	[SdmDomStorage("exampleventmgmt")]
	public class Event : SdmObject<Event>
	{
		/// <summary>
		/// Gets or sets the name of the event.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description of the event.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the start date and time of the event.
		/// </summary>
		public DateTime Start { get; set; }

		/// <summary>
		/// Gets or sets the end date and time of the event.
		/// </summary>
		public DateTime End { get; set; }

		/// <summary>
		/// Gets or sets the type of the event.
		/// </summary>
		public EventType Type { get; set; }

		/// <summary>
		/// Gets or sets the priority of the event.
		/// </summary>
		public EventPriority Priority { get; set; }

		/// <summary>
		/// Gets or sets the list of languages associated with the event.
		/// </summary>
		public List<Language> Languages { get; set; } = new List<Language>();
	}
}
