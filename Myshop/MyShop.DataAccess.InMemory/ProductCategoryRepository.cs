using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
  public  class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategeory> productsa = new List<ProductCategeory>();
        public ProductCategoryRepository()
        {
            productsa = cache["productsa"] as List<ProductCategeory>;
            if (productsa == null)
            {
                productsa = new List<ProductCategeory>();
            }
        }
        public void Commit()
        {
            cache["productsa"] = productsa;
        }
        public void Insert(ProductCategeory p)
        {
            productsa.Add(p);
        }
        public void Update(ProductCategeory product)
        {
            ProductCategeory productupdate = productsa.Find(p => p.Id == product.Id);
            if (productupdate != null)
            {
                productupdate = product;
            }
            else
            {
                throw new Exception("Product no found");
            }
        }
        public ProductCategeory Find(string Id)
        {
            ProductCategeory product = productsa.Find(p => p.Id == Id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product no found");
            }
        }
        public IQueryable<ProductCategeory> Collection()
        {
            return productsa.AsQueryable();
        }
        public void Delete(string Id)
        {
            ProductCategeory product = productsa.Find(p => p.Id == Id);
            if (product != null)
            {
                productsa.Remove(product);
            }
            else
            {
                throw new Exception("Product no found");
            }
        }
    }
}
