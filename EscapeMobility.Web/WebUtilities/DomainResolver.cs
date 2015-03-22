using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EscapeMobility.Web.WebUtilities
{
    public static class DomainResolver
    {
        public static bool IsDevSubDomain(HttpContextBase context)
        {
            var url = context.Request.Headers["HOST"];
            var index = url.IndexOf(".");

            if (index < 0)
                return false;

            var subDomain = url.Substring(0, index);

            if (subDomain == "dev")
            {
                return true;
            }
            return false;


        }
    }
}
