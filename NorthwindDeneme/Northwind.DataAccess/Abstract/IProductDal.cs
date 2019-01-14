using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccess.Concrete;

namespace Northwind.DataAccess.Abstract
{
  public  interface IProductDal:IEntityRepostory<Product>
  {
     
  }
}
