namespace MVCAppTemplate.Database.Migrations.Seeders
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using MVCAppTemplate.Contracts.Database;
    using MVCAppTemplate.DatabaseModels;

    public class SettingsSeeder
    {
        public static void Seed(IDbContext databaseContext)
        {
            if (!databaseContext.SiteSettings.Any())
            {
                var testSetting = new SiteSetting()
                {
                    Id = 1,
                    Name = "Test",
                    Value = "Test Value",
                    CreatedOn = DateTime.Now,
                    Description = "Testing settings seeder"
                };

                databaseContext.SiteSettings.AddOrUpdate(testSetting);
                databaseContext.SaveChanges();
            }
        }
    }
}
