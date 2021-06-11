using AccessServices.DTOs;
using AccessServices.Infrastructure;
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
using System.Windows.Shapes;

namespace ProductsWPF
{
    /// <summary>
    /// Interaction logic for EditCategory.xaml
    /// </summary>
    public partial class EditCategory : Window
    {
        CategoryService categoryService;
        public event Action ItemEdited;
        CategoryDTO _category;
        public EditCategory(CategoryDTO category)
        {
            categoryService = new CategoryService();
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
