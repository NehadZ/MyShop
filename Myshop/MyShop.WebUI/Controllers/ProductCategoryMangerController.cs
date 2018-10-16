using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.DataAccess.InMemory;
using MyShop.Core.Models;
using MyShop.Core.Contracts;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryMangerController : Controller
    {


        IInMemoryRepository<ProductCategeory> context;
        public ProductCategoryMangerController(IInMemoryRepository<ProductCategeory> context)
        {
            this.context = context;
        }
        // GET: ProductManger
        public ActionResult Index()
        {
            
            List<ProductCategeory> products = context.collection().ToList();
            return View(products);
        }




        public ActionResult Create()
        {
            ProductCategeory product = new ProductCategeory();
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(ProductCategeory product)
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
            ProductCategeory product = context.Find(Id);
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
        public ActionResult Edit(ProductCategeory product, string Id)
        {
            ProductCategeory productToedit = context.Find(Id);
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
                productToedit.Id = product.Id;
               

                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            ProductCategeory Producttodelete = context.Find(Id);
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
            ProductCategeory producttodelete = context.Find(Id);
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