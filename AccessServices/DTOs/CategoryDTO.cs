using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AccessServices.DTOs
{
    public class CategoryDTO : IDataErrorInfo
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (Name == "hello")
                        {
                            error = "Возраст должен быть больше 0 и меньше 100";
                        }
                        break;
                }
                return error;
            }
        }
        public string Error => throw new NotImplementedException();
    }
}
