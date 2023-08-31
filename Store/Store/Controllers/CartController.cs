﻿using Microsoft.AspNetCore.Mvc;
using Store.Entities;
using Store.Models;

namespace Store.Controllers
{
    public class CartController : Controller
    {
        StoreContext context = new StoreContext();
        public IActionResult AddCart(Cart cart)
        {
            List<Cart> cart3 = context.Cart.ToList();
            ViewData["Carts"] = cart3;
            //if (ModelState.IsValid)
            //{
                Cart cart2 = context.Cart.FirstOrDefault(x => x.cust_id == cart.cust_id && x.prod_id == cart.prod_id);
                if (cart2 == null) 
                {
                    Product product = context.Product.FirstOrDefault(x => x.Id == cart.prod_id);
                    if (product.Quantity >= cart.Quantity)
                    {
                        context.Cart.Add(cart);
                        context.SaveChanges();
                        return View("Details", product);
                    }
                    else
                    {
                        ViewData["Error"] = "This is not vaild Quantity";
                        return View("Details",product);
                    }
                }
                else
                {
                    cart.Quantity = cart.Quantity + cart2.Quantity;
                    Product product = context.Product.FirstOrDefault(x => x.Id == cart.prod_id);
                    if(product.Quantity >= cart.Quantity)
                    {
                        context.Cart.Update(cart); 
                        context.SaveChanges();
                        return View("Detials",product);
                    }
                    else
                    {
                        ViewData["Error"] = "This is not vaild Quantity";
                        return View("Details",product);
                    }
                }
            //}
            //else
            //{
            //    return View("Details");
            //}
        }

        public IActionResult CartView(int id) 
        {
            List<Cart> cart = context.Cart.Where(x => x.cust_id == id).ToList();
            ViewData["Products"] = context.Product.ToList();
            return View(cart);
        }

        public IActionResult Update(Cart cart) 
        {
            context.Cart.Update(cart);
            context.SaveChanges();
            int? id = HttpContext.Session.GetInt32("ID");
            List<Cart> cart1 = context.Cart.Where(x => x.cust_id == id).ToList();
            ViewData["Products"] = context.Product.ToList();
            return View("CartView",cart1);
        }

        public IActionResult Delete(int id) 
        {
            Cart cart = context.Cart.FirstOrDefault(x => x.Id==id);
            context.Cart.Remove(cart);
            context.SaveChanges();
            int? id1 = HttpContext.Session.GetInt32("ID");
            List<Cart> cart1 = context.Cart.Where(x => x.cust_id == id1).ToList();
            ViewData["Products"] = context.Product.ToList();
            return View("CartView", cart1);
        }

        public IActionResult ConfermCart(int id)
        {
            List<Cart> cart = context.Cart.Where(x => x.cust_id == id).ToList();
            List<ConfermCart> confermCarts = cart.Select(c => new ConfermCart
            {
                cust_id = c.cust_id,
                prod_id = c.prod_id,
                Quantity = c.Quantity,
                TotalPrice = CalculateTotalPrice(c.prod_id, c.Quantity),
                PurchaseDate = DateTime.Now
            }).ToList();

            context.ConfermCart.AddRange(confermCarts);
            context.Cart.RemoveRange(cart);
            context.SaveChanges();

            int? id1 = HttpContext.Session.GetInt32("ID");
            List<Cart> cart1 = context.Cart.Where(x => x.cust_id == id1).ToList();
            ViewData["Products"] = context.Product.ToList();
            return View("CartView",cart1);
        }

        private double CalculateTotalPrice(int productId, int quantity)
        {
            double productPrice = GetProductPrice(productId,quantity);
            double totalPrice = productPrice * quantity;
            return totalPrice;
        }

        private double GetProductPrice(int productId,int quantity)
        {
            Product product = context.Product.FirstOrDefault(x => x.Id == productId);
            product.Quantity -= quantity;
            context.Product.Update(product);

            double productPrice = context.Product.FirstOrDefault(x => x.Id == productId).Price;
            return productPrice;
        }
    }
}
