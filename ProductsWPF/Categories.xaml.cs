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

namespace ProductsWPF
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : Page
    {
        public Categories()
        {
            InitializeComponent();

            DbAccesserEF<Category> accesser = new DbAccesserEF<Category>();
            grid.ItemsSource = accesser.GetItems();

            //grid.InitializingNewItem += (o, e) => { accesser.AddItem((Category)e.NewItem); };
            

            grid.RowEditEnding += (o, e) => 
            {
                accesser.EditItem((Category)grid.SelectedItem); 
            };

            
        }
        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (DataGrid)sender;
                DbAccesserEF<Category> accesser = new DbAccesserEF<Category>();
                accesser.DeleteItem((Category)grid.SelectedItem);
            }
        }

    }
}
