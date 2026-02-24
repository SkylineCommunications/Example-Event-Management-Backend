namespace Skyline.DataMiner.Utils.Examples.EventManagement.Models
{
	/// <summary>
	/// Represents a language configuration for event management.
	/// </summary>
	public class Language
	{
		/// <summary>
		/// Gets or sets the name of the language.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the audio type for the language.
		/// </summary>
		public LanguageAudioType AudioType { get; set; }

		/// <summary>
		/// Gets or sets the closed caption supplier company name.
		/// </summary>
		public string CcSupplierCompanyName { get; set; }
	}
}
