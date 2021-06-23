
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
using AccessServices.DTOs;
using AccessServices.Infrastructure;
using Ninject;
using System.Reflection;
using AccessServices.Interfaces;

namespace ProductsWPF
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : Page
    {
        ICategoryService catS;
        public Categories(ICategoryService categoryService)
        {
            catS = categoryService;
            InitializeComponent();
            grid.ItemsSource = catS.GetCategories();
            grid.InitializingNewItem += (o, e) => { catS.AddCategory((CategoryDTO)e.NewItem); grid.ItemsSource = catS.GetCategories();  };

            grid.RowEditEnding += (o, e) => 
            {
                catS.EditCategory((CategoryDTO)e.Row.Item);
            };

            
        }
        private void RefreshItems()
        {
            grid.ItemsSource = catS.GetCategories();
        }
        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (DataGrid)sender;
                catS.DeleteCategory((CategoryDTO)grid.SelectedItem);
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
            var category = (CategoryDTO)item.SelectedCells[0].Item;
            EditCategory editProduct = new EditCategory(category);
            editProduct.ItemEdited += RefreshItems;
            editProduct.Show();
        }

        private void DeleteContext_Click(object o, EventArgs e)
        {
            var menuItem = (MenuItem)o;
            var contextMenu = (ContextMenu)menuItem.Parent;
            var item = (DataGrid)contextMenu.PlacementTarget;
            var category = (CategoryDTO)item.SelectedCells[0].Item;
            catS.DeleteCategory(category);
            RefreshItems();
        }

    }
}
