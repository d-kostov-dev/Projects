namespace MVCAppTemplate.Database.Migrations
{
    using System.Data.Entity.Migrations;

    using MVCAppTemplate.Database.Migrations.Seeders;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            IdentitySeeder.Seed(context);
            SettingsSeeder.Seed(context);

            // Just in case i don't save in any of the seeders
            context.SaveChanges();
        }
    }
}
