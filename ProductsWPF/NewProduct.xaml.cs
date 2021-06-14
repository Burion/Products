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
        ProductDTO _product;
        public NewProduct()
        {
            InitializeComponent();
            productService = new ProductService();
            _product = new ProductDTO();
            CategoryService categoryService = new CategoryService();
            categoryCombo.ItemsSource = categoryService.GetCategories();
            DataContext = _product;
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Add_Click(object o, EventArgs e)
        {
            nameInput.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            descriptionInput.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            priceInput.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            categoryCombo.GetBindingExpression(ComboBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(nameInput) || Validation.GetHasError(descriptionInput) || Validation.GetHasError(priceInput) || Validation.GetHasError(categoryCombo))
            {
                return;
            }
            var category = (CategoryDTO)categoryCombo.SelectedItem;
            _product.CategoryName = (category.Name);
            productService.AddProduct(_product);

            ItemAdded();
            this.Close();
        }

        
    }
}