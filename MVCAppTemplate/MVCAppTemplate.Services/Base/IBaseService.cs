namespace MVCAppTemplate.Services.Base
{
    using System.Collections.Generic;

    public interface IBaseServices
    {
        IDictionary<string, string> GetSettings();
    }
}
