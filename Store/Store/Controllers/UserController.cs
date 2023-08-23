using Microsoft.AspNetCore.Mvc;
using Store.Entities;
using Store.Models;

namespace Store.Controllers
{
    public class UserController : Controller
    {
        StoreContext context = new StoreContext();

        public IActionResult SignInCustomer()
        {
            return View();
        }

        public IActionResult SignUpCustomer()
        {
            return View();
        }

        public IActionResult SignInSeller()
        {
            return View();
        }

        public IActionResult SignUpSeller()
        {
            return View();
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
    }
}
