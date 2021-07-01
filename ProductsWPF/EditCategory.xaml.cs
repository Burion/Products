using AccessServices.Dtos;
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
        private CategoryDto categoryModel;
        public EditCategory(CategoryDto category)
        {
            InitializeComponent();
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            categoryService = kernel.Get<ICategoryService>();

            categoryModel = category;
            DataContext = categoryModel;
        }

        private void Edit_Click(object o, EventArgs e)
        {
            nameInput.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            
            if (Validation.GetHasError(nameInput))
            {
                return;
            }

            categoryService.EditCategory(categoryModel);
            ItemEdited();
            Close();
        }
    }
}
