namespace MVCAppTemplate.Services
{
    using MVCAppTemplate.Contracts.Database;
    using MVCAppTemplate.DatabaseModels;
    using MVCAppTemplate.Services.Base;
    using MVCAppTemplate.Services.Contracts;

    public class CategoryServices : BaseServices<Category>, ICategoryServices
    {
        public CategoryServices(IDataProvider dataProvider)
            : base(dataProvider)
        {
        }
    }
}
