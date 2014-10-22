using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using System.Web.Services.Description;
using Escape.Data;
using Escape.Data.Model;
using EscapeMobility.Web.Mailers;
using EscapeMobility.Web.Models;
using Microsoft.Ajax.Utilities;
using Mvc.Mailer;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;
using Tweetinvi.Core.Extensions;

namespace EscapeMobility.Controllers
{
    public partial class QuoteController : Controller
    {
        EscapeDataContext _db = new EscapeDataContext();

        private IUserMailer _userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }
        // GET: Quote
        public virtual ActionResult Index()
        {
            var vm = new QuoteViewModel();
            if (Session["Cart"] != null)
            {
                ShoppingCart cart = (ShoppingCart) Session["Cart"];
                vm.ShoppingCart = cart;
                return View(vm);
            }
            vm.ShoppingCart = new ShoppingCart();
            vm.ShoppingCart.CartItems = new List<CartItem>();
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Index([Bind(Include = "FirstName,LastName,MiddleName,Title,Company,Email,Phone,Phone2,Address1,Address2,City,State,Zip,Comments,ShoppingCart")] QuoteViewModel vm )
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
                vm.ShoppingCart.DateCreated = DateTime.Now;
                foreach (var cartItem in vm.ShoppingCart.CartItems)
                {
                    cartItem.Product = _db.Product.Find(cartItem.ProductID);
                }
                var customer = new Customer()
                {
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    MiddleName = vm.MiddleName,
                    ShoppingCarts = new Collection<ShoppingCart>()
                    {
                        new ShoppingCart()
                        {
                            CartItems = vm.ShoppingCart.CartItems,
                            DateCreated = DateTime.Now
                        }
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
                    },
                    DateCreated = DateTime.Now
                };
                
                var customerExists =
                    _db.CustomerContact.Where(c => c.Email == vm.Email);
                if (!customerExists.Any())
                {
                    customer.DateCreated = DateTime.Now;
                    _db.Customer.Add(customer);
                    _db.SaveChanges();
                    UserMailer.SendQuoteEmail(vm).Send();
                    return RedirectToAction(MVC.Quote.SubmitSuccess());
                }
                vm.ShoppingCart = (ShoppingCart) Session["Cart"];
                ViewBag.ContactExistsMessage = "We're sorry, someone with that email already exists in our database.";
                return View(vm);

            }
            vm.ShoppingCart = (ShoppingCart)Session["Cart"];
            return View(vm);
        }

        public virtual ActionResult SubmitSuccess()
        {
            return View();
        }

        public virtual ActionResult AddToQuote(int id)
        {
            ShoppingCart cart = null;
            Product product = _db.Product.SingleOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return Content("-1");
            }
            var vm = new AddToQuoteViewModel
            {
                ProductID = product.ProductId,
                Name = product.Title,
                Price = product.Price,
                ShortDescription = product.ShortDescription,
                ImageFileName = product.ImageFileName
            };
            if (Session["Cart"] != null)
            {
                cart = (ShoppingCart) Session["Cart"];
                foreach (var item in cart.CartItems)
                {
                    if (item.ProductID == id)
                    {
                        item.Quantity++;
                    }
                }
                if (!cart.CartItems.Any(c => c.ProductID == id))
                {
                    var cartItem = new CartItem()
                    {
                        ProductID = product.ProductId,
                        Product = product,
                        Quantity = 1
                    };
                    cart.CartItems.Add(cartItem);
                }
                Session["Cart"] = cart;
            }
            else
            {
                var cartItem = new CartItem()
                {
                    ProductID = product.ProductId,
                    Product = product,
                    Quantity = 1
                };
                cart = new ShoppingCart()
                {
                    CartItems = new Collection<CartItem>()
                    {
                        cartItem
                    },
                    DateCreated = DateTime.Now
                };
                Session["Cart"] = cart;
            }
            Session["ItemCount"] = cart.CartItems.Count; 
            return PartialView("_QuoteModal", vm);
        }


        public virtual JsonResult GetItemCount()
        {
            var vm = new ItemCountViewModel()
            {
                Count = (int) Session["ItemCount"]
            };
            return Json(vm, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult Send()
        {
            var vm = new QuoteViewModel()
            {
                FirstName = "John",
                LastName = "Smith"
            };
            ViewData.Model = vm;
            UserMailer.SendQuoteEmail(vm).Send();
            return RedirectToAction(MVC.Quote.SubmitSuccess());
        }

    }
}