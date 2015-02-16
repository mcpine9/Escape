using System.Data.Entity.Migrations;

namespace Escape.Data
{
    public class EscapeDBConfiguration : DbMigrationsConfiguration<EscapeDataModel>
    {
        public EscapeDBConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(EscapeDataModel context)
        {

        }
    }
}
