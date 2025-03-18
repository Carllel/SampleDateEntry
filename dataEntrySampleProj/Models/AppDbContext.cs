using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace dataEntrySampleProj.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<DataEntry> DataEntries { get; set; }
		public DbSet<TrackingNumber> TrackingNumbers { get; set; }
	}

}
