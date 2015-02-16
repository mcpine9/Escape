using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escape.Data;
using Escape.Data.Model;
using EscapeMobility.Web.Mailers;
using EscapeMobility.Web.Models;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;

namespace EscapeMobility.Controllers
{
    public partial class ServiceController : Controller
    {
        EscapeDataModel _db = new EscapeDataModel();
        private IUserMailer _userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }
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
        public virtual ActionResult Contact([Bind(Include = "FirstName,LastName,Title,Company,Email,Phone,Phone2,Address1,Address2,City,State,Zip,Comments")] ContactFormViewModel vm)
        {
            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();

            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                ModelState.AddModelError("", "Captcha answer cannot be empty.");
                return View(vm);
            }

            RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();

            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {
                ModelState.AddModelError("", "Incorrect captcha answer.");
            }
            if (ModelState.IsValid)
            {
                Customer customer = new Customer()
                {
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                
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
                
                customer.DateCreated = DateTime.Now;
                _db.Customers.Add(customer);
                _db.SaveChanges();
                UserMailer.SendContactEmail(vm).Send();
                return RedirectToAction(MVC.Service.SubmitSuccess());

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

        public virtual ActionResult Error()
        {
            return View();
        }
    }
}