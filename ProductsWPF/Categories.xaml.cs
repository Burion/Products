
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
using AccessServices;
using AccessServices.Dtos;
using AccessServices.Infrastructure;
using Ninject;
using System.Reflection;
using AccessServices.Interfaces;
using ProductsWPF.IoC;

namespace ProductsWPF
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : Page
    {
        ICategoryService categoryService;
        public Categories(ICategoryService categoryService)
        {
            InitializeComponent();

            this.categoryService = categoryService;
            grid.ItemsSource = this.categoryService.GetCategories();

            grid.InitializingNewItem += (o, e) => { 
                this.categoryService.AddCategory((CategoryDto)e.NewItem);
                grid.ItemsSource = this.categoryService.GetCategories();  
            };

            grid.RowEditEnding += (o, e) => 
            {
                this.categoryService.EditCategory((CategoryDto)e.Row.Item);
            };
        }
        private void RefreshItems()
        {
            var kernel = new StandardKernel(new IoCBindings());
            var categoryService = kernel.Get<ICategoryService>();
            grid.ItemsSource = categoryService.GetCategories();
        }

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (DataGrid)sender;
                categoryService.DeleteCategory((CategoryDto)grid.SelectedItem);
            }
        }

        private void Add_Click(object o, EventArgs e)
        {
            NewCategory newCategory = new NewCategory();
            newCategory.ItemAdded += RefreshItems;
            newCategory.Show();
        }

        private void EditContext_Click(object o, EventArgs e)
        {
            var menuItem = (MenuItem)o;
            var contextMenu = (ContextMenu)menuItem.Parent;
            var item = (DataGrid)contextMenu.PlacementTarget;
            var category = (CategoryDto)item.SelectedCells[0].Item;

            EditCategory editProduct = new EditCategory(category);
            editProduct.ItemEdited += RefreshItems;
            editProduct.Show();
        }

        private void DeleteContext_Click(object o, EventArgs e)
        {
            var menuItem = (MenuItem)o;
            var contextMenu = (ContextMenu)menuItem.Parent;
            var item = (DataGrid)contextMenu.PlacementTarget;
            var category = (CategoryDto)item.SelectedCells[0].Item;

            categoryService.DeleteCategory(category);
            RefreshItems();
        }
    }
}
