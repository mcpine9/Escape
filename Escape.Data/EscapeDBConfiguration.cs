using System.Data.Entity.Migrations;

namespace Escape.Data
{
    public class EscapeDBConfiguration : DbMigrationsConfiguration<EscapeDataContext>
    {
        public EscapeDBConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(EscapeDataContext context)
        {

        }
    }
}
