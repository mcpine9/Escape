using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EscapeMobility.Web.App_Start.LegacyRouteHandler
{
    public class LegacyRoute : Route 
    {
      public LegacyRoute(string url, string redirectActionName, IRouteHandler routeHandler)
          : base(url, routeHandler)
      {
          RedirectActionName = redirectActionName;
      }
   
      public string RedirectActionName { get; set; }
  }

 public class LegacyRouteHandler : IRouteHandler 
 {
      public IHttpHandler GetHttpHandler(RequestContext requestContext)
      {
          return new LegacyHandler(requestContext);
      }
  }
   
  // The legacy HttpHandler that handles the request
  public class LegacyHandler : MvcHandler 
  {
      public LegacyHandler(RequestContext requestContext) : base(requestContext) { }
   
      protected override void ProcessRequest(HttpContextBase httpContext) 
      {
          string redirectActionName = ((LegacyRoute)RequestContext.RouteData.Route).RedirectActionName;
   
          // ... copy all of the querystring parameters and put them within RouteContext.RouteData.Values

          VirtualPathData data = RouteTable.Routes.GetVirtualPath(RequestContext, redirectActionName, RequestContext.RouteData.Values);
   
          //httpContext.Status = "301 Moved Permanently";
          //httpContext.AppendHeader("Location", data.VirtualPath);     
      }
   }
}