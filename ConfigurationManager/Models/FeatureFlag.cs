using System.ComponentModel.DataAnnotations;

namespace ConfigurationManager.Models
{
	public class FeatureFlag
	{
		[Key]
		public long FeatureId { get; set; }
		public string FeatureName { get; set; }
		public bool Flag { get; set; }
	}
}
