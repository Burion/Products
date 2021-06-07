
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
using DataAccess;
using DataAccess.Infrastructure;
using DataAccess.Models;

namespace ProductsWPF
{
    /// <summary>
    /// Interaction logic for NewDepartment.xaml
    /// </summary>
    public partial class NewDepartment : Window
    {
        public NewDepartment()
        {
            InitializeComponent();
        }

        void SubmitButtonClick(object sender, EventArgs e)
        {
            Category d = new Category() { Name = name.Text, Address = address.Text };
            DbAccesserEF<Category> da = new DbAccesserEF<Category>();
            da.AddItem(d);
            this.Close();
        }
    }
}
