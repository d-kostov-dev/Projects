namespace MVCAppTemplate.Contracts.Database
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using MVCAppTemplate.DatabaseModels;

    public interface IDbContext
    {
        // General
        DbContext DbContext { get; }

        IDbSet<SiteSetting> SiteSettings { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<Category> Categories { get; set; }

        // Methods
        int SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
