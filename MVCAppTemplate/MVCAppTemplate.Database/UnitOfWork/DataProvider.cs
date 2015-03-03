namespace MVCAppTemplate.Database.UnitOfWork
{
    using System;
    using System.Collections.Generic;

    using MVCAppTemplate.Contracts.Database;
    using MVCAppTemplate.Database.Repositories;
    using MVCAppTemplate.DatabaseModels;
    using MVCAppTemplate.DatabaseModels.Base;
    
    public class DataProvider : IDataProvider
    {
        private IDbContext databaseContext;
        private IDictionary<Type, object> createdRepositories;

        public DataProvider(IDbContext context)
        {
            this.databaseContext = context;
            this.createdRepositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> ApplicationUsers
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IDbContext Context
        {
            get { return this.databaseContext; }
        }

        public IRepository<SiteSetting> SiteSettings
        {
            get { return this.GetRepository<SiteSetting>(); }
        }

        public int SaveChanges()
        {
            return this.databaseContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class, IAuditInfo
        {
            var typeOfRepository = typeof(T);

            if (!this.createdRepositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(GenericRepository<T>), this.databaseContext);
                this.createdRepositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.createdRepositories[typeOfRepository];
        }
    }
}
