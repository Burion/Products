using System;
using System.Collections.Generic;
using System.Text;

namespace AccessServices.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string CategoryName { get; set; }
    }
}
