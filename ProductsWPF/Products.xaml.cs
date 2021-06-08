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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        public Products()
        {
            InitializeComponent();
            DbAccesserEF<Product> accesser = new DbAccesserEF<Product>();
            grid.ItemsSource = accesser.GetItems();

            
            grid.RowEditEnding += (o, e) =>
            {
                accesser.EditItem((Product)grid.SelectedItem);
            };
        }
    }
}
