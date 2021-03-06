// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace EscapeMobility.Web.Controllers
{
    public partial class CondoApartmentController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected CondoApartmentController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ProductHighlightList()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ProductHighlightList);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Safety()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Safety);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Details()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Details);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public CondoApartmentController Actions { get { return MVC.CondoApartment; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "CondoApartment";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "CondoApartment";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string ProductHighlightList = "ProductHighlightList";
            public readonly string Index = "Index";
            public readonly string EscapeChair = "EscapeChair";
            public readonly string EscapeCarryChair = "EscapeCarryChair";
            public readonly string EscapeMattress = "EscapeMattress";
            public readonly string Accessories = "Accessories";
            public readonly string Safety = "Safety";
            public readonly string Details = "Details";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string ProductHighlightList = "ProductHighlightList";
            public const string Index = "Index";
            public const string EscapeChair = "EscapeChair";
            public const string EscapeCarryChair = "EscapeCarryChair";
            public const string EscapeMattress = "EscapeMattress";
            public const string Accessories = "Accessories";
            public const string Safety = "Safety";
            public const string Details = "Details";
        }


        static readonly ActionParamsClass_ProductHighlightList s_params_ProductHighlightList = new ActionParamsClass_ProductHighlightList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ProductHighlightList ProductHighlightListParams { get { return s_params_ProductHighlightList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ProductHighlightList
        {
            public readonly string highlight = "highlight";
        }
        static readonly ActionParamsClass_Safety s_params_Safety = new ActionParamsClass_Safety();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Safety SafetyParams { get { return s_params_Safety; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Safety
        {
            public readonly string category = "category";
        }
        static readonly ActionParamsClass_Details s_params_Details = new ActionParamsClass_Details();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Details DetailsParams { get { return s_params_Details; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Details
        {
            public readonly string id = "id";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _MainLeftMenu = "_MainLeftMenu";
                public readonly string _ProductHighlight = "_ProductHighlight";
                public readonly string _SafetyMenu = "_SafetyMenu";
                public readonly string Accessories = "Accessories";
                public readonly string Details = "Details";
                public readonly string EscapeCarryChair = "EscapeCarryChair";
                public readonly string EscapeChair = "EscapeChair";
                public readonly string EscapeMattress = "EscapeMattress";
                public readonly string Index = "Index";
            }
            public readonly string _MainLeftMenu = "~/Views/CondoApartment/_MainLeftMenu.cshtml";
            public readonly string _ProductHighlight = "~/Views/CondoApartment/_ProductHighlight.cshtml";
            public readonly string _SafetyMenu = "~/Views/CondoApartment/_SafetyMenu.cshtml";
            public readonly string Accessories = "~/Views/CondoApartment/Accessories.cshtml";
            public readonly string Details = "~/Views/CondoApartment/Details.cshtml";
            public readonly string EscapeCarryChair = "~/Views/CondoApartment/EscapeCarryChair.cshtml";
            public readonly string EscapeChair = "~/Views/CondoApartment/EscapeChair.cshtml";
            public readonly string EscapeMattress = "~/Views/CondoApartment/EscapeMattress.cshtml";
            public readonly string Index = "~/Views/CondoApartment/Index.cshtml";
            static readonly _SafetyClass s_Safety = new _SafetyClass();
            public _SafetyClass Safety { get { return s_Safety; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _SafetyClass
            {
                static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                public class _ViewNamesClass
                {
                    public readonly string EmergencyAid = "EmergencyAid";
                    public readonly string Lockers = "Lockers";
                    public readonly string Smokehood = "Smokehood";
                }
                public readonly string EmergencyAid = "~/Views/CondoApartment/Safety/EmergencyAid.cshtml";
                public readonly string Lockers = "~/Views/CondoApartment/Safety/Lockers.cshtml";
                public readonly string Smokehood = "~/Views/CondoApartment/Safety/Smokehood.cshtml";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_CondoApartmentController : EscapeMobility.Web.Controllers.CondoApartmentController
    {
        public T4MVC_CondoApartmentController() : base(Dummy.Instance) { }

        [NonAction]
        partial void ProductHighlightListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, EscapeMobility.Web.Models.ProductHighlightModel highlight);

        [NonAction]
        public override System.Web.Mvc.ActionResult ProductHighlightList(EscapeMobility.Web.Models.ProductHighlightModel highlight)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ProductHighlightList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "highlight", highlight);
            ProductHighlightListOverride(callInfo, highlight);
            return callInfo;
        }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void EscapeChairOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult EscapeChair()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EscapeChair);
            EscapeChairOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void EscapeCarryChairOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult EscapeCarryChair()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EscapeCarryChair);
            EscapeCarryChairOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void EscapeMattressOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult EscapeMattress()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EscapeMattress);
            EscapeMattressOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AccessoriesOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Accessories()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Accessories);
            AccessoriesOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void SafetyOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string category);

        [NonAction]
        public override System.Web.Mvc.ActionResult Safety(string category)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Safety);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "category", category);
            SafetyOverride(callInfo, category);
            return callInfo;
        }

        [NonAction]
        partial void DetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Details(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Details);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DetailsOverride(callInfo, id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
