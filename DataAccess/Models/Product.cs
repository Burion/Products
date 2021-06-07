using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
