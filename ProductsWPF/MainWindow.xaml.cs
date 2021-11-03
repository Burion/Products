
using AccessServices.Interfaces;
using AccessServices.Ninject;
using Ninject;
using System;
using System.Windows;
using System.Windows.Controls;

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
