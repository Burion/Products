
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
            Department d = new Department() { Name = name.Text, Address = address.Text };
            DbAccesser<Department> da = new DbAccesser<Department>();
            da.AddItem(d);
            this.Close();
        }
    }
}
