using Microsoft.EntityFrameworkCore;

namespace ConfigurationManager.Models
{
	public class FeatureFlagContext : DbContext
	{
		public FeatureFlagContext(DbContextOptions<FeatureFlagContext> options)
			: base(options)
		{
		}

		public DbSet<FeatureFlag> TodoItems { get; set; }
	}
}
