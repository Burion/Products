using AccessServices.Dtos;
using AccessServices.Infrastructure;
using Ninject;
using ProductsWPF.IoC;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProductsWPF
{
    /// <summary>
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        private readonly ProductService productService;
        public event Action ItemAdded;
        private ProductDto _product;

        public NewProduct()
        {
            InitializeComponent();
            var kernel = new StandardKernel(new IoCBindings());
            
            productService = kernel.Get<ProductService>();
            _product = new ProductDto();
            CategoryService categoryService = kernel.Get<CategoryService>();
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
            
            if (Validation.GetHasError(nameInput) || 
                Validation.GetHasError(descriptionInput) || 
                Validation.GetHasError(priceInput) || 
                Validation.GetHasError(categoryCombo))
            {
                return;
            }
           
            var category = (CategoryDto)categoryCombo.SelectedItem;
            _product.CategoryName = (category.Name);
            productService.AddProduct(_product);

            ItemAdded();
            this.Close();
        }
    }
}