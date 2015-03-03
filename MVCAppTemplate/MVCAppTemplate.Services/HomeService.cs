namespace MVCAppTemplate.Services
{
    using MVCAppTemplate.Contracts.Database;
    using MVCAppTemplate.Services.Base;
    using MVCAppTemplate.Services.Contracts;

    public class HomeServices : BaseServices, IHomeServices
    {
        public HomeServices(IDataProvider dataProvider)
            : base(dataProvider)
        {
        }
    }
}
