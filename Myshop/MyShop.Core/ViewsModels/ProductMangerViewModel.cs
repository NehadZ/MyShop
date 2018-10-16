using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewsModels
{
   public class ProductMangerViewModel
    {
        public Product product { get; set; }
        public IEnumerable<ProductCategeory> productCategeory { get; set; }
    }
}
