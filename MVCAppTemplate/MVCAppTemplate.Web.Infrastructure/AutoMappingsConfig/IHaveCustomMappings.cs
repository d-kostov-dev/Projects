namespace MVCAppTemplate.Web.Infrastructure.AutoMappingsConfig
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
