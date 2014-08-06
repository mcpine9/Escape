using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Data
{
    public class EscapeDBConfiguration : DbConfiguration
    {
        public EscapeDBConfiguration()
        {
            this.SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory());
            this.SetDatabaseInitializer(new EscapeDataInitializer());
        }
    }
}
