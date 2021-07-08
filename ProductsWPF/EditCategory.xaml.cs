using AccessServices.Dtos;
using AccessServices.Interfaces;
using Ninject;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace ProductsWPF
{
    /// <summary>
    /// Interaction logic for EditCategory.xaml
    /// </summary>
    public partial class EditCategory : Window
    {
        private ICategoryService categoryService;
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
