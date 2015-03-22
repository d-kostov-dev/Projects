namespace MVCAppTemplate.Contracts.Database
{
    using System.Linq;

    using MVCAppTemplate.DatabaseModels;
    using MVCAppTemplate.DatabaseModels.Base;

    public interface IDataProvider
    {
        // Properties
        IDbContext Context { get; }

        // Methods
        int SaveChanges();

        IQueryable<T> All<T>() where T : class, IAuditInfo;

        IQueryable<T> AllWithDeleted<T>() where T : class, IAuditInfo;

        T Find<T>(object id) where T : class, IAuditInfo;

        void Add<T>(T entity) where T : class, IAuditInfo;

        void Update<T>(T entity) where T : class, IAuditInfo;

        void Delete<T>(T entity) where T : class, IAuditInfo;

        void Delete<T>(object id) where T : class, IAuditInfo;

        void TotalDelete<T>(T entity) where T : class, IAuditInfo;
    }
}
