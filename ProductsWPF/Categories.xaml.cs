using DataAccess.Infrastructure.EfCore;
using DataAccess.Models;
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

namespace ProductsWPF
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : Page
    {
        CategoryService catS;
        public Categories()
        {
            InitializeComponent();

            //DbAccesserEF<Category> accesser = new DbAccesserEF<Category>();
            catS = new CategoryService();
            
            grid.ItemsSource = catS.GetCategories();

            grid.InitializingNewItem += (o, e) => { catS.AddCategory((CategoryDTO)e.NewItem); };


            grid.RowEditEnding += (o, e) => 
            {
                catS.EditCategory((CategoryDTO)e.Row.Item);
            };

            
        }
        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (DataGrid)sender;
                catS.DeleteCategory((CategoryDTO)grid.SelectedItem);
            }
        }

    }
}
