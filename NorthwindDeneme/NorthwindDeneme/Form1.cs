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
using Northwind.DataAccess.Concrete;
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
            _categoryService=new CategoryManager(new EfCategoryDal());
        }

        private IProductService _productService;
        private ICategoryService _categoryService;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
            LoadCategories2();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetlAll();
            cbxCategory.ValueMember = "CategoryId";
            cbxCategory.DisplayMember = "CategoryName";
        }
        private void LoadCategories2()
        {
            cbxCategoryID.DataSource = _categoryService.GetlAll();
            cbxCategoryID.ValueMember = "CategoryId";
            cbxCategoryID.DisplayMember = "CategoryName";
        }
        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));

            }
            catch (Exception exception)
            {
 
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtProductName.Text))
            {
                dgwProduct.DataSource = _productService.GetProductsByProductName(txtProductName.Text);

            }
            else
            {
                LoadProducts();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productService.Add(new Product
            {
                CategoryId = Convert.ToInt32(cbxCategoryID.SelectedValue),
                ProductName = txtProductName2.Text,
                QuantityPerUnit = txtQuantityPerUnit.Text,
                UnitPrice = Convert.ToDecimal(txtUnitPrice.Text),
                UnitsInStock = Convert.ToInt16(txtStockAmount.Text)
            });
            MessageBox.Show("Ürün Kaydedildi.");
            LoadProducts();
        }
    }
}
