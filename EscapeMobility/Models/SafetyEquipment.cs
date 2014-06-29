using System.Web.Mvc;

namespace EscapeMobility.Controllers
{
    public class SafetyEquipment
    {
        private string _controllerName;

        public SafetyEquipment(ControllerContext context)
        {
            _controllerName = context.RouteData.Values["Controller"].ToString();
        }
    }
}