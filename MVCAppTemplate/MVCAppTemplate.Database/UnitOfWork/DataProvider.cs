namespace MVCAppTemplate.Database.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public IDbContext Context
        {
            get { return this.databaseContext; }
        }

        public IQueryable<T> All<T>() where T : class, IAuditInfo
        {
            return this.GetRepository<T>().All();
        }

        public IQueryable<T> AllWithDeleted<T>() where T : class, IAuditInfo
        {
            return this.GetRepository<T>().AllWithDeleted();
        }

        public T Find<T>(object id) where T : class, IAuditInfo
        {
            return this.GetRepository<T>().Find(id);
        }

        public void Add<T>(T entity) where T : class, IAuditInfo
        {
            this.GetRepository<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : class, IAuditInfo
        {
            this.GetRepository<T>().Update(entity);
        }

        public void Delete<T>(T entity) where T : class, IAuditInfo
        {
            this.GetRepository<T>().Delete(entity);
        }

        public void Delete<T>(object id) where T : class, IAuditInfo
        {
            this.GetRepository<T>().Delete(id);
        }

        public void TotalDelete<T>(T entity) where T : class, IAuditInfo
        {
            this.GetRepository<T>().TotalDelete(entity);
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
