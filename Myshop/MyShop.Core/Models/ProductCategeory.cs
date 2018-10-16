using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
   public class ProductCategeory
    {
        public string Id { get; set; }

        [StringLength(20)]
        public string Category { get; set; }
      
        public ProductCategeory()
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
