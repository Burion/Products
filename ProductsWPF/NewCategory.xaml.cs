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
    /// Interaction logic for NewCategory.xaml
    /// </summary>
    public partial class NewCategory : Window
    {
        private CategoryDto _category;
        public event Action ItemAdded;

        public NewCategory()
        {
            _category = new CategoryDto();
            InitializeComponent();
            DataContext = _category;
        }

        private void Add_Click(object o, EventArgs e)
        {
            nameInput.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            
            if(Validation.GetHasError(nameInput))
            {
                return;
            }
            
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            
            ICategoryService categoryService = kernel.Get<ICategoryService>();

            try
            {
                categoryService.AddCategory(_category);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType() } - Category with similar name already exists.");
            }
            
            ItemAdded();
            this.Close();
        }
    }
}
