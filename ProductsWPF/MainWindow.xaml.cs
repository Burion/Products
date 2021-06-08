using DataAccess.Infrastructure.EfCore;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DbAccesserEF<Category> db = new DbAccesserEF<Category>();
            var categories = db.GetItems();
        }

        void AddDepartmentClick(object o, EventArgs e)
        {
            Categories categories = new Categories();
            mainFrame.Navigate(categories);
        }
    }
}
