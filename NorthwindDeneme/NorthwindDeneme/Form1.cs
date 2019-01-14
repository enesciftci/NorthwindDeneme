using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwin.Business.Abstract;
using Northwin.Business.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Concrete.NHibernate;

namespace NorthwindDeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _productService=new ProductManager(new EfProductDal());
        }

        private IProductService _productService;
        private void Form1_Load(object sender, EventArgs e)
        {
            
            dgwProduct.DataSource = _productService.GetAll();
        }
    }
}
