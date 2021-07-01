
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
using AccessServices.Dtos;
using AccessServices.Infrastructure;

namespace ProductsWPF
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        ProductServiceUniversal productsService;
        public Products()
        {
            InitializeComponent();
            productsService = new ProductServiceUniversal();
            grid.ItemsSource = productsService.GetProducts();

            CategoryService categoryService = new CategoryService();
            var categories = categoryService.GetCategories();

            grid.InitializingNewItem += (o, e) => { productsService.AddProduct((ProductDto)e.NewItem); };
            grid.RowEditEnding += (o, e) =>
            {
                productsService.EditProduct((ProductDto)e.Row.Item);
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

        private void EditContext_Click(object o, RoutedEventArgs e)
        {
            var menuItem = (MenuItem)o;

            var contextMenu = (ContextMenu)menuItem.Parent;

            var item = (DataGrid)contextMenu.PlacementTarget;

            var product = (ProductDto)item.SelectedCells[0].Item;

            EditProduct editProduct = new EditProduct(product);
            editProduct.ItemEdited += RefreshItems;
            editProduct.Show();
        }

        private void DeleteContext_Click(object o, EventArgs e)
        {
            var menuItem = (MenuItem)o;

            var contextMenu = (ContextMenu)menuItem.Parent;

            var item = (DataGrid)contextMenu.PlacementTarget;

            var product = (ProductDto)item.SelectedCells[0].Item;

            productsService.DeleteProduct(product);
            RefreshItems();
        }
    }
}
