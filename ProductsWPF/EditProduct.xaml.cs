using AccessServices.DTOs;
using AccessServices.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductsWPF
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        ProductService productService;
        ProductDTO _product;
        public EditProduct(ProductDTO product)
        {
            productService = new ProductService();
            _product = product;

            InitializeComponent();
        }

        private void Edit_Click(object o, EventArgs e)
        {
            //product.Name = nameInput.Text;
            //product.Description = descriptionInput.Text;
            //product.Price = float.Parse(priceInput.Text);
            //var category = (CategoryDTO)categoryCombo.SelectedItem;
            //product.CategoryName = (category.Name);
            //productService.AddProduct(product, category);

            //ItemAdded();
            //this.Close();
        }
    }
}
