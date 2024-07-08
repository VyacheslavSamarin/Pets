using Microsoft.EntityFrameworkCore;
using Pets.Application.Interfaces;
using Pets.Domain;
using Pets.Persistence.EntityTypeConfigurations;

namespace Pets.Persistence
{
    public class PetsDbContext : DbContext, IPetsDbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public PetsDbContext(DbContextOptions<PetsDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new PetConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
