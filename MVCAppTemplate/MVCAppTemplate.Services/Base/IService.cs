namespace MVCAppTemplate.Services.Base
{
    using System.Collections.Generic;

    public interface IService
    {
        IDictionary<string, string> GetSettings();
    }
}
