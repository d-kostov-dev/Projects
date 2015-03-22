namespace MVCAppTemplate.Services.Base
{
    using System.Collections.Generic;
    using System.Linq;

    using MVCAppTemplate.Contracts.Database;
    using MVCAppTemplate.DatabaseModels;
    using MVCAppTemplate.DatabaseModels.Base;

    public abstract class BaseServices<T> : IBaseServices<T> where T : class, IAuditInfo
    {
        public BaseServices(IDataProvider dataProvider)
        {
            this.Data = dataProvider;
        }

        protected IDataProvider Data { get; private set; }

        public IQueryable<T> GetAll()
        {
            return this.Data.All<T>();
        }

        public T GetById(int id)
        {
            return this.Data.Find<T>(id);
        }

        public void Add(T input)
        {
            this.Data.Add<T>(input);
        }

        public void Update(T input)
        {
            this.Data.Update<T>(input);
        }

        public void Delete(int id)
        {
            this.Data.Delete<T>(id);
        }

        public IDictionary<string, string> GetSettings()
        {
            var settingsList = this.Data.All<SiteSetting>().ToDictionary(x => x.Name, x => x.Value);
            return settingsList;
        }
    }
}
