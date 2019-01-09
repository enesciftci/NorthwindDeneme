using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccess.Concrete;

namespace Northwin.Business.Concrete
{
   public class ProductManager
   {
       private ProductDal _product = new ProductDal();
        public List<Product> GetAll()
        {
            return _product.GetAll();
        }
    }
}
