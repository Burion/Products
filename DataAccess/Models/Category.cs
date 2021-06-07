using DataAccess.Attrubutes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Category
    {
        [NotInsertable]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
