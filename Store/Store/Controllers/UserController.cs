 using Microsoft.AspNetCore.Mvc;
using Store.Entities;
using Store.Models;

namespace Store.Controllers
{
    public class UserController : Controller
    {
        StoreContext context = new StoreContext();

        private readonly IHttpContextAccessor _context;

        public UserController(IHttpContextAccessor context)
        {
            _context = context;
        }

        public IActionResult SignInCustomer(Customer customer)
        {
            return View(customer);
        }

        public IActionResult SignUpCustomer(Customer customer)
        {
            return View(customer);
        }

        public IActionResult SignInSeller(Seller seller)
        {
            return View(seller);
        }

        public IActionResult SignUpSeller(Seller seller)
        {
            return View(seller);
        }

        public IActionResult HomeStore()
        {
            if(HttpContext.Session.GetString("Name") != null) 
            {
                List<Cart> cart = context.Cart.ToList();
                ViewData["Carts"] = cart;
                return View();
            }
            else
            {
                return View("SignInCustomer");
            }
        }

        [HttpPost]
        public IActionResult RegisterCustomer(Customer customer)
        {
            if(ModelState.IsValid != true)
            {
                return View("SignUpCustomer", customer);
            }
            else
            {
                context.Customer.Add(customer);
                context.SaveChanges();
                return View("SignInCustomer");
            }
        }

        public IActionResult LogInCustomer(Customer customer)
        {
            Customer cus = context.Customer.FirstOrDefault(x => x.Email == customer.Email && x.Password == customer.Password);
            if (cus != null)
            {
                List<Cart> cart = context.Cart.ToList();
                ViewData["Carts"] = cart;
                HttpContext.Session.SetString("Name", cus.Name);
                HttpContext.Session.SetInt32("ID", cus.Id);
                HttpContext.Session.SetInt32("KindUser", 0);
                return View("HomeStore");
            }
            else
            {
                ViewData["Error"] = "email or password is not correct";
                return View("SignInCustomer");
            }
        }

        public IActionResult LogInSeller(Seller seller)
        {
            Seller sell = context.Seller.FirstOrDefault(x => x.Email == seller.Email && x.Password == seller.Password);
            if (sell != null)
            {
                _context.HttpContext.Session.SetString("Name", sell.Name);
                _context.HttpContext.Session.SetInt32("ID", sell.Id);
                HttpContext.Session.SetInt32("KindUser", 1);
                return View("HomeStore");
            }
            else
            {
                ViewData["Error"] = "email or password is not correct";
                return View("SignInSeller");
            }
        }

        [HttpPost]
        public IActionResult RegisterSeller(Seller seller)
        {
            if (ModelState.IsValid != true)
            {
                return View("SignUpSeller", seller);
            }
            else
            {
                context.Seller.Add(seller);
                context.SaveChanges();
                return View("SignInSeller");
            }
        }

        public IActionResult ConfermPassword(string ConfPassword, string Password)
        {
            if(ConfPassword == Password)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public IActionResult UnqiueSellerEmail(string Email)
        {
            Seller seller = context.Seller.FirstOrDefault(s => s.Email == Email);
            if(seller == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public IActionResult UnqiueCustomerEmail(string Email)
        {
            Customer customer = context.Customer.FirstOrDefault(s => s.Email == Email);
            if (customer == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public IActionResult LogOut() 
        {
            HttpContext.Session.Clear();
            return View("SignInCustomer");
        }
    }
}
