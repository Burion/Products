using AccessServices.DTOs;
using AccessServices.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        readonly ProductService productService;
        public event Action ItemAdded;
        public NewProduct()
        {
            InitializeComponent();
            productService = new ProductService();
            CategoryService categoryService = new CategoryService();
            categoryCombo.ItemsSource = categoryService.GetCategories();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Add_Click(object o, EventArgs e)
        {

            ProductDTO product = new ProductDTO();
            product.Name = nameInput.Text;
            product.Description = descriptionInput.Text;
            product.Price = float.Parse(priceInput.Text);
            var category = (CategoryDTO)categoryCombo.SelectedItem;
            product.CategoryName = (category.Name);
            productService.AddProduct(product, category);

            ItemAdded();
            this.Close();
        }
    }
}