
using AccessServices.Interfaces;
using AccessServices.Ninject;
using Ninject;
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
        readonly ICategoryService categoryService;
        public MainWindow()
        {

            InitializeComponent();
        }



        private void product_Click(object sender, RoutedEventArgs e)
        {

        }

        void TabSelected(object sender, EventArgs e)
        {
            switch (((TabItem)sender).Header)
            {
                case "Categories":
                    var module = new Bindings();
                    var kernel = new StandardKernel(module);
                    var page = kernel.Get<Categories>();

                    mainFrame.Navigate(page);
                    break;

                case "Products":
                    Products productsPage = new Products();
                    mainFrame.Navigate(productsPage);
                    break;

            }
        }
    }
}
