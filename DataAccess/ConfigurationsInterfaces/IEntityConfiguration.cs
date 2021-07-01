using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ConfigurationsInterfaces
{
    public interface IEntityConfiguration
    {
        public void Configure();
    }
}
