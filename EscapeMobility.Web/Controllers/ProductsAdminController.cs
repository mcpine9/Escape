using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Services.Description;
using Escape.Data;
using Escape.Data.Model;
using EscapeMobility.Web.Models;

namespace EscapeMobility.Web.Controllers
{
    public partial class ProductsAdminController : Controller
    {
        private readonly EscapeDataContext _db = new EscapeDataContext();
        
        // GET: ProductsAdmin
        public virtual ActionResult Index()
        {
            var product = _db.Product.ToList();
            var categories = _db.Category.ToList();

            var vm = new ProductsAdminViewModel {SelectedCategories = new Dictionary<int, string>()};
            foreach (var p in product)
            {
                var categoryArray = (from c in categories
                                     from productCategory in c.Products
                                     where productCategory.ProductId == p.ProductId
                                     select c.CategoryName).ToArray();
                vm.SelectedCategories.Add(p.ProductId, String.Join(", ", Array.ConvertAll(categoryArray, Convert.ToString)));
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
            Product product = _db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            vm.Product = product;
            var categories = _db.Category.ToList();
            var categoryArray = (from c in categories
                                 from productCategory in c.Products
                                 where productCategory.ProductId == id
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
            IEnumerable<Category> categories = (from c in _db.Category
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
                    foreach (var category in SelectedProductCategoryIds.Select(ids => _db.Category.Find(ids)))
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
            var product = _db.Product.SingleOrDefault(p => p.ProductId == id);
            var evacuationTypeValues = Enum.GetValues(typeof(EvacuationType));
            var evacuationTypeNames = Enum.GetNames(typeof(EvacuationType)); 
            for (int i = 0; i <= evacuationTypeNames.Length - 1; i++)
            {
                var t = new SelectListItem()
                {
                    Text = evacuationTypeNames[i],
                    Value = evacuationTypeValues.GetValue(i).ToString(),
                    Selected = product != null && (product.EvacuationType.ToString() == evacuationTypeNames[i])
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
                    Value = safetyTypeValues.GetValue(i).ToString(),
                    Selected = product != null && (product.SafetyType.ToString() == safetyTypeNames[i])
                };
                vm.SafetyTypeList.Add(t);
            }
            
            IEnumerable<Category> categories = (from c in _db.Category
                select c);
            if (product != null)
            {
                vm.Product = product;
                vm.ProductCategoryList = categories;
                vm.SelectedProductCategoryIds = (from c in _db.Category
                    from productCategory in c.Products
                    where productCategory.ProductId == id
                    select c.CategoryId).ToList();
            }
            
            return View(vm);
        }

        // POST: ProductsAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "ProductId,Title,ShortDescription,LongDescription,Thumbnailfolder,Price,Discount,ArticleNumber,VideoSampleURL,SafetyTags,SimilarTags,ProductSpecificationId,ImageFileName,IsAccessory,EvacuationType,SafetyType,SelectedProductCategoryIds")] Product product, int[] SelectedProductCategoryIds)
        {
            var vm = new EditProductViewModel();
            if (ModelState.IsValid)
            {
                _db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                _db.Entry(product).Collection(c => c.Categories).Load();
                product.Categories.Clear();
                if (SelectedProductCategoryIds != null)
                {
                    foreach (var category in SelectedProductCategoryIds.Select(ids => _db.Category.Find(ids)))
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
            Product product = _db.Product.Find(id);
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
            Product product = _db.Product.Find(id);
            _db.Product.Remove(product);
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
                _db.Category.Add(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public virtual ActionResult EditSpecification(int id)
        {
            ProductSpecification spec = _db.Product.SingleOrDefault(s => s.ProductId == id).ProductSpecification;
            Product product = _db.Product.Find(id);
            if (spec != null)
            {
                var vm = new ProductSpecificationsViewModel()
                {
                    Armrest = spec.Armrest,
                    ArticleNumber = product.ArticleNumber,
                    Backrest = spec.Backrest,
                    Dimensions = spec.DimensionsFoldedUp,
                    DimentionsFoldedUp = spec.DimensionsFoldedUp,
                    Discount = product.Discount,
                    Footrest = spec.Footrest,
                    HasAniSlipHandle = spec.HasAniSlipHandle,
                    HasDustCover = spec.HasDustCover,
                    HasErgonomicBackrest = spec.HasErgonomicBackrest,
                    HasGlidingBeltSystem = spec.HasGlidingBeltSystem,
                    HasImmobilizationBand = spec.HasImmobilizationBand,
                    HasUnfoldingStand = spec.HasUnfoldingStand,
                    ImageFileName = product.ImageFileName,
                    IsEasyToOperate = spec.IsEasyToOperate,
                    IsReadyForUse = spec.IsReadyForUse,
                    IsSpecificationOn = spec.IsSpecificationOn,
                    LongDescription = product.LongDescription,
                    Material = spec.Material,
                    MaxAngleOfStairs = spec.MaxAngleOfStairs,
                    MaxCarryingCapacity = spec.MaxCarryingCapacity,
                    OperatingHandle = spec.OperatingHandle,
                    HasPaddedHeadRest = spec.HasPaddedHeadRest,
                    Price = product.Price,
                    Seat = spec.Seat,
                    ShortDescription = product.ShortDescription,
                    Title = product.Title,
                    Warranty = spec.LimitedWarranty,
                    Weight = spec.Weight

                };
                return View(vm);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult EditSpecification([Bind(Include = "ProductSpecificationId,IsSpecificationOn,Material,IsEasyToOperate,IsReadyForUse,HasUnfoldingStand,HasErgonomicBackrest,HasGlidingBeltSystem,HasDustCover,HasAniSlipHandle,MaxCarryingCapacity,MaxAngleOfStairs,OperatingHandle,Seat,Backrest,Footrest,Armrest,HasImmobilizationBand,DimensionsFoldedUp,Warranty,Weight,ProductId,HasPaddedHeadRest,LimitedWarranty")] ProductSpecificationsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var spec = new ProductSpecification()
                {
                    Armrest = vm.Armrest,
                    Backrest = vm.Backrest,
                };
                if (productSpecification != null)
                {
                    _db.Entry(productSpecification).CurrentValues.SetValues(prodSpec);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(prodSpec);
        }

        public virtual ActionResult ProductSpecification(int id)
        {
            ProductSpecification spec = _db.Product.SingleOrDefault(s => s.ProductId == id).ProductSpecification;
            if (spec != null)
            {
                var vm = new ProductSpecificationsViewModel()
                {
                    Armrest = spec.Armrest,
                    ArticleNumber = spec.Product.ArticleNumber,
                    Backrest = spec.Backrest,
                    Dimensions = spec.DimensionsFoldedUp,
                    DimentionsFoldedUp = spec.DimensionsFoldedUp,
                    Discount = spec.Product.Discount,
                    Footrest = spec.Footrest,
                    HasAniSlipHandle = spec.HasAniSlipHandle,
                    HasDustCover = spec.HasDustCover,
                    HasErgonomicBackrest = spec.HasErgonomicBackrest,
                    HasGlidingBeltSystem = spec.HasGlidingBeltSystem,
                    HasImmobilizationBand = spec.HasImmobilizationBand,
                    HasUnfoldingStand = spec.HasUnfoldingStand,
                    ImageFileName = spec.Product.ImageFileName,
                    IsEasyToOperate = spec.IsEasyToOperate,
                    IsReadyForUse = spec.IsReadyForUse,
                    IsSpecificationOn = spec.IsSpecificationOn,
                    LongDescription = spec.Product.LongDescription,
                    Material = spec.Material,
                    MaxAngleOfStairs = spec.MaxAngleOfStairs,
                    MaxCarryingCapacity = spec.MaxCarryingCapacity,
                    OperatingHandle = spec.OperatingHandle,
                    HasPaddedHeadRest = spec.HasPaddedHeadRest,
                    Price = spec.Product.Price,
                    Seat = spec.Seat,
                    ShortDescription = spec.Product.ShortDescription,
                    Title = spec.Product.Title,
                    Warranty = spec.LimitedWarranty,
                    Weight = spec.Weight

                };
                return View(vm);
            }
            return View(new ProductSpecificationsViewModel());
        }

        public virtual ActionResult AddSpecification(int id)
        {
            var name = _db.Product.SingleOrDefault(p => p.ProductId == id).Title;
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
                                        LimitedWarranty = vm.LimitedWarranty,
                                        ProductId = vm.ProductId
                                    };
            _db.ProductSpecification.Add(newProdSpec);
            _db.SaveChanges();
            var product = _db.Product.Find(vm.ProductId);
            product.ProductSpecificationId = newProdSpec.ProductSpecificationId;
            var entry = _db.Entry(product);
            entry.Property(p => p.ProductSpecificationId).IsModified = true;
            _db.SaveChanges();
            return RedirectToAction("Index");
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
