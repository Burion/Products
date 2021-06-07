using DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace DataAccess.Infrastructure
{
    class DbAccesserDapper<T> : IDbAccesser<T>
    {
        public void AddItem(T item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(T item)
        {
            throw new NotImplementedException();
        }

        public void EditItem(T original, T toSet)
        {
            throw new NotImplementedException();
        }

        public T GetItem(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetItems(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        void InsertItem(T item)
        {
            var connectionString = ConfigurationManager.AppSettings.Get("connectionString");
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                
            }
        }
    }
}
