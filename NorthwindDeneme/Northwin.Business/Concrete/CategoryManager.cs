using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwin.Business.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;

namespace Northwin.Business.Concrete
{
   public class CategoryManager:ICategoryService
   {
       private ICategoryDal _categoryDal;

       public CategoryManager(ICategoryDal categoryDal)
       {
           _categoryDal = categoryDal;
       }

       public List<Category> GetlAll()
       {
           return _categoryDal.GetAll();
       }
    }
}
