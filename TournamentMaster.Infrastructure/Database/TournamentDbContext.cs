using Microsoft.EntityFrameworkCore;
using TournamentMaster.Domain.Entities;
using TournamentMaster.Infrastructure.Database.Configurations;

namespace TournamentMaster.Infrastructure.Database
{
    public class TournamentDbContext : DbContext
    {
        public TournamentDbContext(DbContextOptions<TournamentDbContext> options): base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("tournamentSystem");

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
