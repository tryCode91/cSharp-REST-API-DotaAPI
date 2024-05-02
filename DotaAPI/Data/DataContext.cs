using DotaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotaAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        
        }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<HeroAbility> HeroAbilities { get; set; }
        public DbSet<AbilityDetail> AbilityDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HeroAbility>()
                .HasKey(ha => new { ha.HeroId, ha.AbilityId });

            modelBuilder.Entity<HeroAbility>()
                .HasOne(h => h.Hero)
                .WithMany(ha => ha.HeroAbilities)
                .HasForeignKey(h => h.HeroId);

            modelBuilder.Entity<HeroAbility>()
                .HasOne(h => h.Ability)
                .WithMany(ha => ha.HeroAbilities)
                .HasForeignKey(h => h.AbilityId);
        }
    }
}
