using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Escape.Data;
using Escape.Data.Model;
using EscapeMobility.Web.Models;
using Ninject.Infrastructure.Language;

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

            var vm = new ProductsAdminViewModel();
            vm.SelectedCategories = new Dictionary<int, string>();
            foreach (var p in product)
            {
                var categoryArray = (from c in categories
                                     from productCategory in c.Products
                                     where productCategory.ProductId == p.ProductId
                                     select c.CategoryName).ToArray();
                vm.SelectedCategories.Add(p.ProductId, String.Join(", ", Array.ConvertAll(categoryArray, Convert.ToString)));
            }
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
            var vm = new ProductsAdminDetailsViewModel();
            vm.SelectedCategories = new Dictionary<int, string>();
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
            var vm = new CreateProductViewModel();
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
        public virtual ActionResult Create([Bind(Include = "ProductId,Title,ShortDescription,LongDescription,Thumbnailfolder,Price,Discount,ArticleNumber,VideoSampleURL,SafetyTags,SimilarTags,ProductSpecificationId,ImageFileName,IsAccessory, EvacuationType, SelectedProductCategoryIds")] Product product, int[] SelectedProductCategoryIds)
        {
            var vm = new CreateProductViewModel();
            if (ModelState.IsValid)
            {
                _db.Entry(product).State = System.Data.Entity.EntityState.Added;
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

        // GET: ProductsAdmin/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new EditProductViewModel();
            var itemValues = Enum.GetValues(typeof(EvacuationType));
            var itemNames = Enum.GetNames(typeof(EvacuationType)); 
            for (int i = 0; i <= itemNames.Length - 1; i++)
            {
                var item = new ListItem(itemNames[i], itemValues[i]);
                vm.EvacuationTypeList.Add(item);
            }
            Product product = _db.Product.SingleOrDefault(p => p.ProductId == id);
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
        public virtual ActionResult Edit([Bind(Include = "ProductId,Title,ShortDescription,LongDescription,Thumbnailfolder,Price,Discount,ArticleNumber,VideoSampleURL,SafetyTags,SimilarTags,ProductSpecificationId,ImageFileName,IsAccessory,EvacuationType,SelectedProductCategoryIds")] Product product, int[] SelectedProductCategoryIds)
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
