namespace MVCAppTemplate.Services
{
    using MVCAppTemplate.Contracts.Database;
    using MVCAppTemplate.DatabaseModels;
    using MVCAppTemplate.Services.Base;
    using MVCAppTemplate.Services.Contracts;

    public class PostServices : BaseServices<Post>, IPostServices
    {
        public PostServices(IDataProvider dataProvider)
            : base(dataProvider)
        {
        }
    }
}
