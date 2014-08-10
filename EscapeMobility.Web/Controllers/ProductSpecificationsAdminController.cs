using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Escape.Data;
using Escape.Data.Model;

namespace EscapeMobility.Web.Controllers
{
    public partial class ProductSpecificationsAdminController : Controller
    {
        private EscapeDataContext db = new EscapeDataContext();

        // GET: ProductSpecificationsAdmin
        public virtual ActionResult Index()
        {
            var productSpecification = db.ProductSpecification.Include(p => p.Product);
            return View(productSpecification.ToList());
        }

        // GET: ProductSpecificationsAdmin/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSpecification productSpecification = db.ProductSpecification.Find(id);
            if (productSpecification == null)
            {
                return HttpNotFound();
            }
            return View(productSpecification);
        }

        // GET: ProductSpecificationsAdmin/Create
        public virtual ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Product, "ProductId", "Title");
            return View();
        }

        // POST: ProductSpecificationsAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Include = "ProductId,ProductSpecificationID,IsSpecificationOn,Material,IsEasyToOperate,IsReadyForUse,HasUnfoldingStand,HasErgonomicBackrest,HasGlidingBeltSystem,HasDustCover,HasAniSlipHandle,MaxCarryingCapacity,MaxAngleOfStairs,OperatingHandle,Seat,Backrest,Footrest,Armrest,HasImmobilizationBand,HasPaddedHeadrest,DimentionsFoldedUp,Waranty")] ProductSpecification productSpecification)
        {
            if (ModelState.IsValid)
            {
                db.ProductSpecification.Add(productSpecification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Product, "ProductId", "Title", productSpecification.ProductId);
            return View(productSpecification);
        }

        // GET: ProductSpecificationsAdmin/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSpecification productSpecification = db.ProductSpecification.Find(id);
            if (productSpecification == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Product, "ProductId", "Title", productSpecification.ProductId);
            return View(productSpecification);
        }

        // POST: ProductSpecificationsAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "ProductId,ProductSpecificationID,IsSpecificationOn,Material,IsEasyToOperate,IsReadyForUse,HasUnfoldingStand,HasErgonomicBackrest,HasGlidingBeltSystem,HasDustCover,HasAniSlipHandle,MaxCarryingCapacity,MaxAngleOfStairs,OperatingHandle,Seat,Backrest,Footrest,Armrest,HasImmobilizationBand,HasPaddedHeadrest,DimentionsFoldedUp,Waranty")] ProductSpecification productSpecification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSpecification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Product, "ProductId", "Title", productSpecification.ProductId);
            return View(productSpecification);
        }

        // GET: ProductSpecificationsAdmin/Delete/5
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSpecification productSpecification = db.ProductSpecification.Find(id);
            if (productSpecification == null)
            {
                return HttpNotFound();
            }
            return View(productSpecification);
        }

        // POST: ProductSpecificationsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            ProductSpecification productSpecification = db.ProductSpecification.Find(id);
            db.ProductSpecification.Remove(productSpecification);
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
