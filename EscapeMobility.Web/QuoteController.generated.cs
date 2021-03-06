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
namespace EscapeMobility.Controllers
{
    public partial class QuoteController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public QuoteController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected QuoteController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult AddToQuote()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddToQuote);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult RemoveFromQuote()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveFromQuote);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public QuoteController Actions { get { return MVC.Quote; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Quote";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Quote";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string SubmitSuccess = "SubmitSuccess";
            public readonly string AddToQuote = "AddToQuote";
            public readonly string RemoveFromQuote = "RemoveFromQuote";
            public readonly string GetItemCount = "GetItemCount";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string SubmitSuccess = "SubmitSuccess";
            public const string AddToQuote = "AddToQuote";
            public const string RemoveFromQuote = "RemoveFromQuote";
            public const string GetItemCount = "GetItemCount";
        }


        static readonly ActionParamsClass_Index s_params_Index = new ActionParamsClass_Index();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Index IndexParams { get { return s_params_Index; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Index
        {
            public readonly string vm = "vm";
        }
        static readonly ActionParamsClass_AddToQuote s_params_AddToQuote = new ActionParamsClass_AddToQuote();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddToQuote AddToQuoteParams { get { return s_params_AddToQuote; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddToQuote
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_RemoveFromQuote s_params_RemoveFromQuote = new ActionParamsClass_RemoveFromQuote();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_RemoveFromQuote RemoveFromQuoteParams { get { return s_params_RemoveFromQuote; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_RemoveFromQuote
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
                public readonly string _QuoteItems = "_QuoteItems";
                public readonly string _QuoteModal = "_QuoteModal";
                public readonly string Index = "Index";
                public readonly string SubmitSuccess = "SubmitSuccess";
            }
            public readonly string _MainLeftMenu = "~/Views/Quote/_MainLeftMenu.cshtml";
            public readonly string _QuoteItems = "~/Views/Quote/_QuoteItems.cshtml";
            public readonly string _QuoteModal = "~/Views/Quote/_QuoteModal.cshtml";
            public readonly string Index = "~/Views/Quote/Index.cshtml";
            public readonly string SubmitSuccess = "~/Views/Quote/SubmitSuccess.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_QuoteController : EscapeMobility.Controllers.QuoteController
    {
        public T4MVC_QuoteController() : base(Dummy.Instance) { }

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
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, EscapeMobility.Web.Models.QuoteViewModel vm);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index(EscapeMobility.Web.Models.QuoteViewModel vm)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "vm", vm);
            IndexOverride(callInfo, vm);
            return callInfo;
        }

        [NonAction]
        partial void SubmitSuccessOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult SubmitSuccess()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SubmitSuccess);
            SubmitSuccessOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AddToQuoteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddToQuote(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddToQuote);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            AddToQuoteOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void RemoveFromQuoteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult RemoveFromQuote(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveFromQuote);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            RemoveFromQuoteOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void GetItemCountOverride(T4MVC_System_Web_Mvc_JsonResult callInfo);

        [NonAction]
        public override System.Web.Mvc.JsonResult GetItemCount()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetItemCount);
            GetItemCountOverride(callInfo);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
