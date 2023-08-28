using Microsoft.AspNetCore.Mvc;
using Store.Entities;
using Store.Models;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        StoreContext context = new StoreContext();

        public IActionResult MyProducts()
        {
            List<Product> products = context.Product.ToList();
            return View(products);
        }

        public IActionResult New(Product product) 
        {
            return View(product);
        }

        public IActionResult Save(Product product) 
        {
            if (ModelState.IsValid != true)
            {
                return View("New", product);
            }
            else
            {
                context.Product.Add(product);
                context.SaveChanges();
                return RedirectToAction("MyProducts");
            }
        }

        public IActionResult Details(int id) 
        {
            Product product = context.Product.FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        public IActionResult Edit(int id) 
        {
            Product product = context.Product.FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Save1(Product product) 
        {
            if (ModelState.IsValid)
            {
                context.Product.Update(product);
                context.SaveChanges();
                return RedirectToAction("MyProducts");
            }
            else 
            {
                return View("Edit",product);
            }
        }

        //public IActionResult Delete(int id) 
        //{
        //    Product product = context.Product.FirstOrDefault(x =>x.Id == id);
        //    context.Product.Remove(product);
        //    context.SaveChanges();
        //    return Json(true);
        //}

        public IActionResult CheckIntNegative(int Quantity)
        {
            if (Quantity > 0)
            {
                return Json(true);
            }
            else 
            {
                return Json(false);
            }
        }

        public IActionResult CheckDoubleNegative(double Price)
        {
            if (Price > 0)
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
