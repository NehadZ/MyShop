using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class ProductMangerController : Controller
    {
        ProductRepository context;
        public ProductMangerController()
        {
            context = new ProductRepository();
        }
        // GET: ProductManger
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }




        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();

            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product productToedit = context.Find(Id);
            if (productToedit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                productToedit.Category = product.Category;
                productToedit.Description = product.Description;
                productToedit.Image = product.Image;
                productToedit.Name = product.Name;
                productToedit.Price = product.Price;

                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Product Producttodelete = context.Find(Id);
            if (Producttodelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(Producttodelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product producttodelete = context.Find(Id);
            if (producttodelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

    }
}
