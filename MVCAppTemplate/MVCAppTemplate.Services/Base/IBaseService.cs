namespace MVCAppTemplate.Services.Base
{
    using System.Collections.Generic;
    using System.Linq;

    using MVCAppTemplate.DatabaseModels.Base;

    public interface IBaseServices<T> : IService
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        void Add(T input);

        void Update(T input);

        void Delete(int id);
    }
}
