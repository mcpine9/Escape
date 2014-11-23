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
    public partial class ProductsAdminController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ProductsAdminController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ProductsAdminController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult Details()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Details);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Edit()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Delete()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult DeleteConfirmed()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteConfirmed);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult EditSpecification()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditSpecification);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ProductSpecification()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ProductSpecification);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult AddSpecification()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddSpecification);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ProductsAdminController Actions { get { return MVC.ProductsAdmin; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "ProductsAdmin";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "ProductsAdmin";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Details = "Details";
            public readonly string Create = "Create";
            public readonly string Edit = "Edit";
            public readonly string Delete = "Delete";
            public readonly string DeleteConfirmed = "Delete";
            public readonly string AddCategory = "AddCategory";
            public readonly string EditSpecification = "EditSpecification";
            public readonly string ProductSpecification = "ProductSpecification";
            public readonly string AddSpecification = "AddSpecification";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Details = "Details";
            public const string Create = "Create";
            public const string Edit = "Edit";
            public const string Delete = "Delete";
            public const string DeleteConfirmed = "Delete";
            public const string AddCategory = "AddCategory";
            public const string EditSpecification = "EditSpecification";
            public const string ProductSpecification = "ProductSpecification";
            public const string AddSpecification = "AddSpecification";
        }


        static readonly ActionParamsClass_Details s_params_Details = new ActionParamsClass_Details();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Details DetailsParams { get { return s_params_Details; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Details
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Create s_params_Create = new ActionParamsClass_Create();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Create CreateParams { get { return s_params_Create; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Create
        {
            public readonly string product = "product";
            public readonly string SelectedProductCategoryIds = "SelectedProductCategoryIds";
        }
        static readonly ActionParamsClass_Edit s_params_Edit = new ActionParamsClass_Edit();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Edit EditParams { get { return s_params_Edit; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Edit
        {
            public readonly string id = "id";
            public readonly string product = "product";
            public readonly string SelectedProductCategoryIds = "SelectedProductCategoryIds";
        }
        static readonly ActionParamsClass_Delete s_params_Delete = new ActionParamsClass_Delete();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Delete DeleteParams { get { return s_params_Delete; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Delete
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_DeleteConfirmed s_params_DeleteConfirmed = new ActionParamsClass_DeleteConfirmed();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteConfirmed DeleteConfirmedParams { get { return s_params_DeleteConfirmed; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteConfirmed
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_AddCategory s_params_AddCategory = new ActionParamsClass_AddCategory();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddCategory AddCategoryParams { get { return s_params_AddCategory; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddCategory
        {
            public readonly string CategoryName = "CategoryName";
        }
        static readonly ActionParamsClass_EditSpecification s_params_EditSpecification = new ActionParamsClass_EditSpecification();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditSpecification EditSpecificationParams { get { return s_params_EditSpecification; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditSpecification
        {
            public readonly string id = "id";
            public readonly string spec = "spec";
        }
        static readonly ActionParamsClass_ProductSpecification s_params_ProductSpecification = new ActionParamsClass_ProductSpecification();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ProductSpecification ProductSpecificationParams { get { return s_params_ProductSpecification; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ProductSpecification
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_AddSpecification s_params_AddSpecification = new ActionParamsClass_AddSpecification();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddSpecification AddSpecificationParams { get { return s_params_AddSpecification; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddSpecification
        {
            public readonly string id = "id";
            public readonly string vm = "vm";
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
                public readonly string AddCategory = "AddCategory";
                public readonly string AddSpecification = "AddSpecification";
                public readonly string Create = "Create";
                public readonly string Delete = "Delete";
                public readonly string Details = "Details";
                public readonly string Edit = "Edit";
                public readonly string EditSpecification = "EditSpecification";
                public readonly string Index = "Index";
            }
            public readonly string AddCategory = "~/Views/ProductsAdmin/AddCategory.cshtml";
            public readonly string AddSpecification = "~/Views/ProductsAdmin/AddSpecification.cshtml";
            public readonly string Create = "~/Views/ProductsAdmin/Create.cshtml";
            public readonly string Delete = "~/Views/ProductsAdmin/Delete.cshtml";
            public readonly string Details = "~/Views/ProductsAdmin/Details.cshtml";
            public readonly string Edit = "~/Views/ProductsAdmin/Edit.cshtml";
            public readonly string EditSpecification = "~/Views/ProductsAdmin/EditSpecification.cshtml";
            public readonly string Index = "~/Views/ProductsAdmin/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ProductsAdminController : EscapeMobility.Web.Controllers.ProductsAdminController
    {
        public T4MVC_ProductsAdminController() : base(Dummy.Instance) { }

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
        partial void DetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Details(int? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Details);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DetailsOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            CreateOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Escape.Data.Model.Product product, int[] SelectedProductCategoryIds);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create(Escape.Data.Model.Product product, int[] SelectedProductCategoryIds)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "product", product);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "SelectedProductCategoryIds", SelectedProductCategoryIds);
            CreateOverride(callInfo, product, SelectedProductCategoryIds);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Edit(int? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            EditOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Escape.Data.Model.Product product, int[] SelectedProductCategoryIds);

        [NonAction]
        public override System.Web.Mvc.ActionResult Edit(Escape.Data.Model.Product product, int[] SelectedProductCategoryIds)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "product", product);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "SelectedProductCategoryIds", SelectedProductCategoryIds);
            EditOverride(callInfo, product, SelectedProductCategoryIds);
            return callInfo;
        }

        [NonAction]
        partial void DeleteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Delete(int? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeleteOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void DeleteConfirmedOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult DeleteConfirmed(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteConfirmed);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeleteConfirmedOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void AddCategoryOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddCategory()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddCategory);
            AddCategoryOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AddCategoryOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string CategoryName);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddCategory(string CategoryName)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddCategory);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "CategoryName", CategoryName);
            AddCategoryOverride(callInfo, CategoryName);
            return callInfo;
        }

        [NonAction]
        partial void EditSpecificationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditSpecification(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditSpecification);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            EditSpecificationOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void EditSpecificationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Escape.Data.Model.ProductSpecification spec);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditSpecification(Escape.Data.Model.ProductSpecification spec)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditSpecification);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "spec", spec);
            EditSpecificationOverride(callInfo, spec);
            return callInfo;
        }

        [NonAction]
        partial void ProductSpecificationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult ProductSpecification(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ProductSpecification);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ProductSpecificationOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void AddSpecificationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddSpecification(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddSpecification);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            AddSpecificationOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void AddSpecificationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, EscapeMobility.Web.Models.AddProductSpecificationsViewModel vm);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddSpecification(EscapeMobility.Web.Models.AddProductSpecificationsViewModel vm)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddSpecification);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "vm", vm);
            AddSpecificationOverride(callInfo, vm);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
