using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Entities;
using Store.Models;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        StoreContext context = new StoreContext();
        private IWebHostEnvironment env;

        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            env = webHostEnvironment;
        }

        public IActionResult MyProducts(int Id)
        {
            if (HttpContext.Session.GetString("Name") != null) 
            {
                List<Product> products = context.Product.Where(x => x.sell_id == Id).ToList();
                return View(products);
            }
            else
            {
                return View("SignInCustomer");
            }
        }

        public IActionResult New(Product product) 
        {
            if (HttpContext.Session.GetString("Name") != null)
            {
                return View(product);
            }
            else
            {
                return View("SignInCustomer");
            }
        }

        public async Task<IActionResult> Save(Product product) 
        {
            if (ModelState.IsValid != true)
            {
                return View("New", product);
            }
            else
            {
                string wwwRootPath = env.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                product.Image = fileName + DateTime.Now.ToString("yymmssff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image" , product.Image);
                using(var filestream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(filestream);
                }


                context.Product.Add(product);
                context.SaveChanges();

                int? Id = HttpContext.Session.GetInt32("ID");

                List<Product> products = context.Product.Where(x => x.sell_id == Id).ToList();

                return View("MyProducts",products);
            }
        }

        public IActionResult Details(int id) 
        {
            if(HttpContext.Session.GetString("Name") != null) 
            {
                List<Cart> cart = context.Cart.ToList();
                ViewData["Carts"] = cart;
                Product product = context.Product.FirstOrDefault(x => x.Id == id);
                return View(product);
            }
            else
            {
                return View("SignInCustomer");
            }
        }

        public IActionResult Edit(int id) 
        {
            if(HttpContext.Session.GetString("Name") != null)
            {
                Product product = context.Product.FirstOrDefault(x => x.Id == id);
                return View(product);
            }
            else
            {
                return View("SignInCustomer");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save1([Bind("Id,Name,Description,Quantity,Price,ImageFile,sell_id")] Product product) 
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = env.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                product.Image = fileName + DateTime.Now.ToString("yymmssff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", product.Image);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(filestream);
                }

                context.Product.Update(product);
                context.SaveChanges();

                int? Id = HttpContext.Session.GetInt32("ID");

                List<Product> products = context.Product.Where(x => x.sell_id == Id).ToList();

                return View("MyProducts", products);
            }
            else 
            {
                return View("Edit",product);
            }
        }

        public IActionResult Search(string searchString)
        {
            List<Cart> cart = context.Cart.ToList();
            ViewData["Carts"] = cart;
            List<Product> products = context.Product.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            return View(products);
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
