namespace MVCAppTemplate.Contracts.Database
{
    using MVCAppTemplate.DatabaseModels;

    public interface IDataProvider
    {
        // General
        IDbContext Context { get; }

        IRepository<ApplicationUser> ApplicationUsers { get; }

        IRepository<SiteSetting> SiteSettings { get; }

        // Methods
        int SaveChanges();
    }
}
