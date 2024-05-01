using BlazorServerApp.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.Api.Infrastructure
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {

        }

        DbSet<Camera> Cameras => Set<Camera>();
        DbSet<Accessory> Accessories => Set<Accessory>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Camera>()
                .ToTable("Cameras", c => c.IsTemporal());

            modelBuilder
                .Entity<Accessory>()
                .ToTable("Accessories", c => c.IsTemporal());

            base.OnModelCreating(modelBuilder);
        }
    }
}
