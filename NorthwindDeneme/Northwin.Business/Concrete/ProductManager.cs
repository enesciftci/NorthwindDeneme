﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwin.Business.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;

namespace Northwin.Business.Concrete
{
   public class ProductManager:IProductService
   {
       private IProductDal _productDal;

       public ProductManager(IProductDal productDal)
       {
           _productDal = productDal;
       }

        public void Add(Product product)
        {
           _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
            }
            catch 
            {
               throw new Exception("Silme Gerçekleşmedi");
            }
        }

        public List<Product> GetAll()
       {
           return _productDal.GetAll();
       }

       public List<Product> GetProductsByCategory(int categoryId)
       {
           return _productDal.GetAll(p => p.CategoryId == categoryId);
       }

       public object GetProductsByProductName(string productName)
       {
           return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));
       }

        public void Update(Product product)
        {
          _productDal.Update(product);
        }
    }
}
