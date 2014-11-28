using System.Data.Entity.Migrations;

namespace Escape.Data
{
    public class ApplicationDBConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public ApplicationDBConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {

        }
    }
}