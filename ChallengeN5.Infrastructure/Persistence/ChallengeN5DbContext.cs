using ChallengeN5.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5.Infrastructure.Persistence
{
	public class ChallengeN5DbContext : DbContext
	{
		public ChallengeN5DbContext(DbContextOptions<ChallengeN5DbContext> options) : base(options)
		{
		}

		public DbSet<Permissions> Permissions { get; set; }
        public DbSet<PermissionTypes> PermissionTypes { get; set; }
    }
}

