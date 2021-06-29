using AccessServices.Dtos;
using AccessServices.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        private ProductService productService;
        private ProductDto _product;
        public event Action ItemEdited;
        IEnumerable<CategoryDto> categories;
        CategoryDto Category { 
            get 
            { 
                return categories.Single(c => _product.CategoryName == c.Name); 
            }
        }
        public EditProduct(ProductDto product)
        {
            productService = new ProductService();
            _product = product;
            CategoryService categoryService = new CategoryService();
            categories = categoryService.GetCategories();
            DataContext = new { _product, Category };
            InitializeComponent();
            categoryCombo.ItemsSource = categories;
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Edit_Click(object o, EventArgs e)
        {
            nameInput.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            descriptionInput.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            priceInput.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(nameInput) || Validation.GetHasError(descriptionInput) || Validation.GetHasError(priceInput) || Validation.GetHasError(categoryCombo))
            {
                return;
            }
            _product.CategoryName = ((CategoryDto)categoryCombo.SelectedItem).Name;
            productService.EditProduct(_product);

            ItemEdited();
            this.Close();
        }
    }
}
