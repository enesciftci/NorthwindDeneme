using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Northwin.Business.Abstract;
using Northwin.Business.Concrete;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;

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
            LoadCategoriesForUpdate();
            
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.ValueMember = "CategoryId";
            cbxCategory.DisplayMember = "CategoryName";
        }

        private void LoadCategories2()
        {
            cbxCategoryID.DataSource = _categoryService.GetAll();
            cbxCategoryID.ValueMember = "CategoryId";
            cbxCategoryID.DisplayMember = "CategoryName";
        }
        private void LoadCategoriesForUpdate()
        {
            cbxUCategoryID.DataSource = _categoryService.GetAll();
            cbxUCategoryID.ValueMember = "CategoryId";
            cbxUCategoryID.DisplayMember = "CategoryName";
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
                dgwProduct.DataSource =
                    _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));

            }
            catch
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

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUProductName.Text = dgwProduct.CurrentRow.Cells[2].Value.ToString();
            txtUUnitPrice.Text = dgwProduct.CurrentRow.Cells[3].Value.ToString();
            txtUQuantityPerUnit.Text = dgwProduct.CurrentRow.Cells[4].Value.ToString();
            txtUStockAmount.Text = dgwProduct.CurrentRow.Cells[5].Value.ToString();
            cbxUCategoryID.SelectedValue = dgwProduct.CurrentRow.Cells[1].Value;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductId =Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                CategoryId = Convert.ToInt32(cbxUCategoryID.SelectedValue),
                ProductName=txtUProductName.Text,
                QuantityPerUnit = txtUQuantityPerUnit.Text,
                UnitPrice = Convert.ToDecimal(txtUUnitPrice.Text),
             UnitsInStock = Convert.ToInt16(txtUStockAmount.Text)
            });
            MessageBox.Show("Ürün Güncellendi");
            LoadProducts();
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgwProduct.CurrentRow != null)
            {
                try
                {

                    _productService.Delete(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)
                    });
                    LoadProducts(); 
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

           
        }
    }
}
