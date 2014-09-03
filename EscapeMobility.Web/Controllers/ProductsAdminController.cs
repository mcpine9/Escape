using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Escape.Data;
using Escape.Data.Model;
using EscapeMobility.Web.Models;
using Microsoft.Ajax.Utilities;
using Ninject.Infrastructure.Language;
using WebGrease.Css.Extensions;

namespace EscapeMobility.Controllers
{
    public partial class ProductsAdminController : Controller
    {
        private readonly EscapeDataContext db = new EscapeDataContext();
        
        // GET: ProductsAdmin
        public virtual ActionResult Index()
        {
            return View(db.Product.ToList());
        }

        // GET: ProductsAdmin/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: ProductsAdmin/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: ProductsAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Include = "ProductId,Title,ShortDescription,LongDescription,Thumbnailfolder,Price,Discount,ArticleNumber,VideoSampleURL,SafetyTags,SimilarTags,ProductSpecificationId,IsAccessory, Categories")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: ProductsAdmin/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new ProductsAdminViewModel();
            Product product = db.Product.SingleOrDefault(p => p.ProductId == id);
            IEnumerable<Category> categories = (from c in db.Category
                select c);
            if (product != null)
            {
                vm.Product = product;
                vm.ProductCategoryList = categories;
                vm.SelectedProductCategoryIds = (from c in db.Category
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
        public virtual ActionResult Edit([Bind(Include = "ProductId,Title,ShortDescription,LongDescription,Thumbnailfolder,Price,Discount,ArticleNumber,VideoSampleURL,SafetyTags,SimilarTags,ProductSpecificationId,IsAccessory,SelectedProductCategoryIds")] Product product, int[] SelectedProductCategoryIds)
        {
            if (ModelState.IsValid)
            {
                product.Categories = db.Category.Where(x => SelectedProductCategoryIds.Contains(x.CategoryId)).ToList();
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: ProductsAdmin/Delete/5
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
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
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
