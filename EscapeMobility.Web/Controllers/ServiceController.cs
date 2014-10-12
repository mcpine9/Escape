using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escape.Data;
using Escape.Data.Model;
using EscapeMobility.Web.Models;

namespace EscapeMobility.Controllers
{
    public partial class ServiceController : Controller
    {
        EscapeDataContext _db = new EscapeDataContext();
        // GET: Service
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult CustomerService()
        {
            return RedirectToAction("Index");
        }

        public virtual ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Contact([Bind(Include = "FirstName,LastName,MiddleName,Title,Company,Email,Phone,Phone2,Address1,Address2,City,State,Zip,Comments")] ContactFormViewModel vm)
        {

            if (ModelState.IsValid)
            {
                Customer customer = new Customer()
                {
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    MiddleName = vm.MiddleName,
                
                    CustomerContacts = new Collection<CustomerContact>()
                    {
                        new CustomerContact()
                        {
                            Title = vm.Title,
                            Company = vm.Company,
                            Email = vm.Email,
                            Phone = vm.Phone,
                            Phone2 = vm.Phone2,
                            Address1 = vm.Address1,
                            Address2 = vm.Address2,
                            City = vm.City,
                            State = vm.State,
                            Zip = vm.Zip,
                            Comments = vm.Comments,
                            DateAdded = DateTime.Now
                        }
                    }
                };
                bool customerExists =
                    _db.Customer.Select(c => c.CustomerContacts.Select(t => t.Email == vm.Email)).Any();
                if (!customerExists)
                {
                    customer.DateCreated = DateTime.Now;
                    _db.Customer.Add(customer);
                    _db.SaveChanges();
                    return RedirectToAction(MVC.Service.SubmitSuccess());
                }
                ViewBag.ContactExistsMessage = "We're sorry, someone with that email already exists in our database.";
                return View(vm);

            }
            return View(vm);
        }

        public virtual ActionResult SubmitSuccess()
        {
            return View();
        }

        public virtual ActionResult PrivacyStatement()
        {
            return View();
        }

        public virtual ActionResult Terms()
        {
            return View();
        }
    }
}