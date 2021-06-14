using AccessServices.DTOs;
using AccessServices.Infrastructure;
using AccessServices.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductsWPF
{
    /// <summary>
    /// Interaction logic for EditCategory.xaml
    /// </summary>
    public partial class EditCategory : Window
    {
        ICategoryService categoryService;
        public event Action ItemEdited;
        CategoryDTO _category;
        public EditCategory(CategoryDTO category)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            categoryService = kernel.Get<ICategoryService>();
            _category = category;
            InitializeComponent();
            DataContext = _category;
        }

        private void Edit_Click(object o, EventArgs e)
        {
            categoryService.EditCategory(_category);
            ItemEdited();
            Close();
        }
    }
}
