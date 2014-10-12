using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escape.Data;
using Escape.Data.Model;
using EscapeMobility.Web.Models;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;
using Tweetinvi.Core.Extensions;

namespace EscapeMobility.Controllers
{
    public partial class QuoteController : Controller
    {
        EscapeDataContext _db = new EscapeDataContext();
        // GET: Quote
        public virtual ActionResult Index()
        {
            var vm = new QuoteViewModel();
            int cartId = (int) Session["CartId"];
            if (!cartId.ToString().IsNullOrEmpty())
            {
                vm.ShoppingCart = (_db.ShoppingCart.Where(shoppingCart => shoppingCart.ShoppingCartId == cartId)
                    .Select(shoppingCart => new ShoppingCart())
                    ).SingleOrDefault();

            }
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Index([Bind(Include = "FirstName,LastName,MiddleName,Title,Company,Email,Phone,Phone2,Address1,Address2,City,State,Zip,Comments")] QuoteViewModel vm)
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
                    MiddleName = vm.MiddleName,
                    ShoppingCarts = new Collection<ShoppingCart>()
                    {
                        vm.ShoppingCart
                    },
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

        public virtual ActionResult AddToQuote(int productID)
        {
            return Content("Success");
        }
    }
}