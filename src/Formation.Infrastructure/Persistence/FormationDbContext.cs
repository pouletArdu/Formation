using Formation.Infrastructure.Entities.Common;

namespace Formation.Infrastructure.Persistence
{
    public class FormationDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public FormationDbContext(DbContextOptions<FormationDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Author>()
                    .Property(e => e.Gender)
                        .HasConversion(
                                g=> g.ToString(),
                                g=> (Gender)Enum.Parse(typeof(Gender), g.ToString()));
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.Now;
                        entry.Entity.ModificationDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModificationDate = DateTime.Now;
                        break;
                }
            }
            
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
