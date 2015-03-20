﻿namespace MVCAppTemplate.Services.Base
{
    using System.Collections.Generic;
    using System.Linq;

    using MVCAppTemplate.Contracts.Database;
    using MVCAppTemplate.DatabaseModels;
    
    public abstract class BaseServices : IBaseServices
    {
        public BaseServices(IDataProvider dataProvider)
        {
            this.Data = dataProvider;
        }

        protected IDataProvider Data { get; private set; }

        public IDictionary<string, string> GetSettings()
        {
            var settingsList = this.Data.All<SiteSetting>().ToDictionary(x => x.Name, x => x.Value);
            return settingsList;
        }
    }
}
