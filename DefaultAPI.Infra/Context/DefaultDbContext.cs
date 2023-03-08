using DefaultAPI.Domain.Entities;
using DefaultAPI.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DefaultAPI.Infra.Context
{
    public class DefaultDbContext : DbContext
    {
        public DbSet<DefaultClass> DefaulClasses { get; set; }
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity &&
                    (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).InsertedDate = DateTime.Now;
                    entity.Property("InsertedDate").IsModified = false;
                }

                if (entity.State == EntityState.Modified)
                {
                    ((BaseEntity)entity.Entity).UpdatedDate = DateTime.Now;
                    entity.Property("UpdatedDate").IsModified = true;
                    entity.Property("InsertedDate").IsModified = false;
                }
            }

            return base.SaveChangesAsync();
        }
    }
}
