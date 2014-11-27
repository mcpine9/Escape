using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Escape.Data.Model;

namespace Escape.Data
{
    public class EscapeDataInitializer : DropCreateDatabaseIfModelChanges<EscapeDataContext>
    {
        protected override void Seed(EscapeDataContext context)
        {
            
            base.Seed(context);
        }

    }
}
