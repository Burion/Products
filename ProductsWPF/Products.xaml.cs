
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AccessServices.DTOs;
using AccessServices.Infrastructure;

namespace ProductsWPF
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        ProductService productsService;
        public Products()
        {
            InitializeComponent();
            productsService = new ProductService();
            grid.ItemsSource = productsService.GetProducts();

            CategoryService categoryService = new CategoryService();
            var categories = categoryService.GetCategories();

            grid.InitializingNewItem += (o, e) => { productsService.AddProduct((ProductDTO)e.NewItem); };
            grid.RowEditEnding += (o, e) =>
            {
                productsService.EditProduct((ProductDTO)e.Row.Item);
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewProduct newProduct = new NewProduct();
            newProduct.ItemAdded += RefreshItems;
            newProduct.Show();
        }

        private void RefreshItems()
        {
            grid.ItemsSource = productsService.GetProducts();
        }
    }
}
