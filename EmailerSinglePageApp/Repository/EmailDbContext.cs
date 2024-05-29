using EmailerSinglePageApp.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailerSinglePageApp.Repository
{
    public class EmailDbContext : DbContext
	{
		public EmailDbContext(DbContextOptions<EmailDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Email>()
				.Property(e => e.Importance)
				.HasConversion(
					v => v.ToString(),
					v => (Importance)Enum.Parse(typeof(Importance), v));
		}

		public DbSet<Email> Emails { get; set; }
	}
}
