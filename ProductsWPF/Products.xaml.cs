
using System;
using System.Windows;
using System.Windows.Controls;
using AccessServices.Dtos;
using AccessServices.Infrastructure;
using AccessServices.Interfaces;
using Ninject;
using ProductsWPF.IoC;

namespace ProductsWPF
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        IProductService productsService;
        ICategoryService categoryService;

        public Products()
        {
            InitializeComponent();

            var kernel = new StandardKernel(new IoCBindings());
            productsService = kernel.Get<IProductService>();
            
            grid.ItemsSource = productsService.GetProducts();
            categoryService = kernel.Get<CategoryService>();
            
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
            var kernel = new StandardKernel(new IoCBindings());
            productsService = kernel.Get<IProductService>();
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
