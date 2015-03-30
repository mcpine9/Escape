using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Services.Description;
using Escape.Data;
using Escape.Data.Model;
using EscapeMobility.Web.Models;
using Newtonsoft.Json;

namespace EscapeMobility.Web.Controllers
{
    //[Authorize]
    public partial class ProductsAdminController : Controller
    {
        private readonly EscapeDataModel _db = new EscapeDataModel();
        
        // GET: ProductsAdmin
        public virtual ActionResult Index()
        {
            var product = _db.Products.ToList();
            var categories = _db.Categories.ToList();

            var vm = new ProductsAdminViewModel {SelectedCategories = new Dictionary<int, string>()};
            foreach (var p in product)
            {
                var categoryArray = (from c in categories
                                     from productCategory in c.Products
                                     where productCategory.Id == p.Id
                                     select c.CategoryName).ToArray();
                vm.SelectedCategories.Add(p.Id, String.Join(", ", Array.ConvertAll(categoryArray, Convert.ToString)));
            }
            vm.NumberOfProducts = product.Count;
            vm.Products = product;
            return View(vm);
        }

        // GET: ProductsAdmin/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new ProductsAdminDetailsViewModel {SelectedCategories = new Dictionary<int, string>()};
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            vm.Product = product;
            var categories = _db.Categories.ToList();
            var categoryArray = (from c in categories
                                 from productCategory in c.Products
                                 where productCategory.Id == id
                                 select c.CategoryName).ToArray();
            vm.SelectedCategories.Add((int) id, String.Join(", ", Array.ConvertAll(categoryArray, Convert.ToString)));
            return View(vm);
        }

        // GET: ProductsAdmin/Create
        public virtual ActionResult Create()
        {
            var vm = new CreateProductViewModel
            {
                EvacuationTypeList = new List<SelectListItem>(),
                SafetyTypeList = new List<SelectListItem>()
            };
            var evacuationTypeValues = Enum.GetValues(typeof(EvacuationType));
            var evacuationTypeNames = Enum.GetNames(typeof(EvacuationType));
            for (int i = 0; i <= evacuationTypeNames.Length - 1; i++)
            {
                var t = new SelectListItem()
                {
                    Text = evacuationTypeNames[i],
                    Value = evacuationTypeValues.GetValue(i).ToString()
                };
                vm.EvacuationTypeList.Add(t);
            }
            var safetyTypeValues = Enum.GetValues(typeof(SafetyType));
            var safetyTypeNames = Enum.GetNames(typeof(SafetyType));
            for (int i = 0; i <= safetyTypeNames.Length - 1; i++)
            {
                var t = new SelectListItem()
                {
                    Text = safetyTypeNames[i],
                    Value = safetyTypeValues.GetValue(i).ToString()
                };
                vm.SafetyTypeList.Add(t);
            }
            IEnumerable<Category> categories = (from c in _db.Categories
                                                select c);
                vm.ProductCategoryList = categories;
            
            return View(vm);
        }

        // POST: ProductsAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Include = "ProductId,Title,ShortDescription,LongDescription,Thumbnailfolder,Price,Discount,ArticleNumber,VideoSampleURL,SafetyTags,SimilarTags,ProductSpecificationId,ImageFileName,IsAccessory,EvacuationType,SafetyType,SelectedProductCategoryIds")] Product product, int[] SelectedProductCategoryIds)
        {
            var vm = new CreateProductViewModel();
            if (ModelState.IsValid)
            {
                _db.Entry(product).State = System.Data.Entity.EntityState.Added;
                product.Categories = new Collection<Category>();
                if (SelectedProductCategoryIds != null)
                {
                    foreach (var category in SelectedProductCategoryIds.Select(ids => _db.Categories.Find(ids)))
                    {
                        product.Categories.Add(category);
                    }
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.Product = product;
            return View(vm);
        }

        // GET: ProductsAdmin/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new EditProductViewModel
            {
                EvacuationTypeList = new List<SelectListItem>(),
                SafetyTypeList = new List<SelectListItem>()
            };
            var product = _db.Products.SingleOrDefault(p => p.Id == id);
            var evacuationTypeValues = Enum.GetValues(typeof(EvacuationType)).Cast<int>().ToArray();
            var evacuationTypeNames = Enum.GetNames(typeof(EvacuationType)); 
            for (int i = 0; i <= evacuationTypeNames.Length - 1; i++)
            {
                var t = new SelectListItem()
                {
                    Text = evacuationTypeNames[i],
                    Value = evacuationTypeValues[i].ToString(),
                    Selected = product != null && (product.EvacuationType == evacuationTypeValues[i])
                };
                vm.EvacuationTypeList.Add(t);
            }
            var safetyTypeValues = Enum.GetValues(typeof(SafetyType)).Cast<int>().ToArray();
            var safetyTypeNames = Enum.GetNames(typeof(SafetyType));
            for (int i = 0; i <= safetyTypeNames.Length - 1; i++)
            {
                var t = new SelectListItem()
                {
                    Text = safetyTypeNames[i],
                    Value = safetyTypeValues[i].ToString(),
                    Selected = product != null && (product.SafetyType == safetyTypeValues[i])
                };
                vm.SafetyTypeList.Add(t);
            }
            
            IEnumerable<Category> categories = (from c in _db.Categories
                select c);
            if (product != null)
            {
                vm.Product = product;
                vm.ProductCategoryList = categories;
                vm.SelectedProductCategoryIds = (from c in _db.Categories
                    from productCategory in c.Products
                    where productCategory.Id == id
                    select c.CategoryId).ToList();
            }
            
            return View(vm);
        }

        // POST: ProductsAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual ActionResult Edit([Bind(Include = "Id, Title, ShortDescription, LongDescription, Thumbnailfolder, Price, Discount, ArticleNumber, VideoSampleURL, SafetyTags, RelatedTags, IsAccessory, ImageFileName, ProductSpecificationId, EvacuationType, SafetyType, SelectedProductCategoryIds")] Product product, int[] SelectedProductCategoryIds)
        {
            var vm = new EditProductViewModel();
            if (ModelState.IsValid)
            {
                _db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                _db.Entry(product).Collection(c => c.Categories).Load();
                product.Categories.Clear();
                if (SelectedProductCategoryIds != null)
                {
                    foreach (var category in SelectedProductCategoryIds.Select(ids => _db.Categories.Find(ids)))
                    {
                        product.Categories.Add(category);
                    }
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.Product = product;
            return View(vm);
        }

        // GET: ProductsAdmin/Delete/5
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ProductsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            Product product = _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public virtual ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult AddCategory(string CategoryName)
        {
            if (ModelState.IsValid)
            {
                var cat = new Category()
                {
                    CategoryName = CategoryName
                };
                _db.Categories.Add(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public virtual ActionResult EditSpecification(int id)
        {
            Product product = _db.Products.Find(id);
            ProductSpecification spec = product.ProductSpecification;
            if (spec != null)
            {
                var vm = new EditSpecificationViewModel()
                {
                    Armrest = spec.Armrest,
                    Backrest = spec.Backrest,
                    DimensionsFoldedUp = spec.DimensionsFoldedUp,
                    Footrest = spec.Footrest,
                    HasAniSlipHandle = spec.HasAniSlipHandle,
                    HasDustCover = spec.HasDustCover,
                    HasErgonomicBackrest = spec.HasErgonomicBackrest,
                    HasGlidingBeltSystem = spec.HasGlidingBeltSystem,
                    HasImmobilizationBand = spec.HasImmobilizationBand,
                    HasUnfoldingStand = spec.HasUnfoldingStand,
                    IsEasyToOperate = spec.IsEasyToOperate,
                    IsReadyForUse = spec.IsReadyForUse,
                    Material = spec.Material,
                    MaxAngleOfStairs = spec.MaxAngleOfStairs,
                    MaxCarryingCapacity = spec.MaxCarryingCapacity,
                    OperatingHandle = spec.OperatingHandle,
                    HasPaddedHeadRest = spec.HasPaddedHeadRest,
                    Seat = spec.Seat,
                    LimitedWarranty = spec.LimitedWarranty,
                    Weight = spec.Weight

                };
                return View(vm);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult EditSpecification([Bind(Include = "ProductSpecificationId,IsSpecificationOn,Material,IsEasyToOperate,IsReadyForUse,HasUnfoldingStand,HasErgonomicBackrest,HasGlidingBeltSystem,HasDustCover,HasAniSlipHandle,MaxCarryingCapacity,MaxAngleOfStairs,OperatingHandle,Seat,Backrest,Footrest,Armrest,HasImmobilizationBand,DimensionsFoldedUp,Warranty,Weight,ProductId,HasPaddedHeadRest,LimitedWarranty")] EditSpecificationViewModel vm)
        {
            if (ModelState.IsValid)
            {
                ProductSpecification ps = _db.ProductSpecifications.Find(vm.ProductSpecificationId);
                var spec = new ProductSpecification()
                {
                    Armrest = vm.Armrest,
                    Backrest = vm.Backrest,
                    DimensionsFoldedUp = vm.DimensionsFoldedUp,
                    IsEasyToOperate = vm.IsEasyToOperate, 
                    IsReadyForUse = vm.IsReadyForUse, 
                    HasUnfoldingStand = vm.HasUnfoldingStand, 
                    HasErgonomicBackrest = vm.HasErgonomicBackrest, 
                    HasGlidingBeltSystem = vm.HasGlidingBeltSystem, 
                    HasDustCover = vm.HasDustCover, 
                    HasAniSlipHandle = vm.HasAniSlipHandle, 
                    MaxCarryingCapacity = vm.MaxCarryingCapacity, 
                    MaxAngleOfStairs = vm.MaxAngleOfStairs, 
                    OperatingHandle = vm.OperatingHandle, 
                    Seat = vm.Seat, 
                    Footrest = vm.Footrest, 
                    HasImmobilizationBand = vm.HasImmobilizationBand,
                    Weight = vm.Weight, 
                    HasPaddedHeadRest = vm.HasPaddedHeadRest, 
                    LimitedWarranty = vm.LimitedWarranty 

                };
                if (ps != null)
                {
                    _db.Entry(ps).CurrentValues.SetValues(spec);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(vm);
        }

        public virtual ActionResult ProductSpecification(int id)
        {
            Product product = _db.Products.Find(id);
            ProductSpecification spec = product.ProductSpecification;
            if (spec != null)
            {
                var vm = new ProductSpecificationsViewModel()
                {
                    ArticleNumber = product.ArticleNumber,
                    Discount = product.Discount,
                    ImageFileName = product.ImageFileName,
                    LongDescription = product.LongDescription,
                    Price = product.Price,
                    ShortDescription = product.ShortDescription,
                    Title = product.Title

                };
                return View(vm);
            }
            return View(new ProductSpecificationsViewModel());
        }

        public virtual ActionResult AddSpecification(int id)
        {
            var name = _db.Products.SingleOrDefault(p => p.Id == id).Title;
            var vm = new AddProductSpecificationsViewModel()
            {
                ProductId = id,
                ProductName = name
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult AddSpecification(AddProductSpecificationsViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var newProdSpec = new ProductSpecification()
                                    {
                                        Material = vm.Material,
                                        IsEasyToOperate = vm.IsEasyToOperate,
                                        IsReadyForUse = vm.IsReadyForUse,
                                        HasUnfoldingStand = vm.HasUnfoldingStand,
                                        HasErgonomicBackrest = vm.HasErgonomicBackrest,
                                        HasGlidingBeltSystem = vm.HasGlidingBeltSystem,
                                        HasDustCover = vm.HasDustCover,
                                        HasAniSlipHandle = vm.HasAniSlipHandle,
                                        MaxCarryingCapacity = vm.MaxCarryingCapacity,
                                        MaxAngleOfStairs = vm.MaxAngleOfStairs,
                                        OperatingHandle = vm.OperatingHandle,
                                        Seat = vm.Seat,
                                        Backrest = vm.Backrest,
                                        Footrest = vm.Footrest,
                                        Armrest = vm.Armrest,
                                        HasImmobilizationBand = vm.HasImmobilizationBand,
                                        HasPaddedHeadRest = vm.HasPaddedHeadRest,
                                        DimensionsFoldedUp = vm.DimensionsFoldedUp,
                                        Weight = vm.Weight,
                                        LimitedWarranty = vm.LimitedWarranty
                                    };
            Product product = _db.Products.Find(vm.ProductId);
            product.ProductSpecification = newProdSpec;
            _db.SaveChanges();
            

            return RedirectToAction("Index");
        }

        public virtual ActionResult AddCustomSpecs(int productId)
        {
            var vm = new AddCustomSpecsViewModel();
            Product product = _db.Products.SingleOrDefault(p => p.Id == productId);
            if (product != null)
            {
                vm.productId = productId;
                vm.Product = product;
            }
            return View(vm);

        }

        [HttpPost]
        public virtual JsonResult AddCustomSpecs([Bind(Include = "json,productId,Show,ShowInProd")] AddCustomSpecsViewModel vm)
        {
            Product product = null;
            var spec = new CustomSpecification()
            {
                SpecificationObject = vm.json,
                Show = vm.Show,
                ShowInProd = vm.ShowInProd
            };
            try
            {
                product = _db.Products.SingleOrDefault(p => p.Id == vm.productId);
                if (product.CustomSpecifications.Count > 0)
                {
                    _db.CustomeSpecifications.Remove(product.CustomSpecifications.First());
                    _db.SaveChanges();
                }
                product.CustomSpecifications.Add(spec);
                _db.SaveChanges();

            }
            catch (Exception e)
            {
                if (product == null)
                {
                    throw new NullReferenceException("There are no products with that ID.");
                }
                throw new Exception(e.Message);
            }

            return Json("ok");
        }

        public virtual ActionResult RemoveCustomSpecs(int customSpecId)
        {
            var cSpec = _db.CustomeSpecifications.FirstOrDefault(s => s.CustomSpecificationId == customSpecId);
            try
            {
                _db.CustomeSpecifications.Remove(cSpec);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(MVC.ProductsAdmin.Index());
        }

        public virtual ActionResult UpdateCustomSpecs(int productId)
        {
            CustomSpecification spec = _db.CustomeSpecifications.Single(s => s.Products.Any(p => p.Id == productId));
            var vm = new UpdateCustomSpecsViewModel()
            {
                Product = _db.Products.SingleOrDefault(p => p.Id == productId),
                productId = productId,
                json = spec.SpecificationObject,
                Show = spec.Show,
                ShowInProd = spec.ShowInProd
            };

            return View(vm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
