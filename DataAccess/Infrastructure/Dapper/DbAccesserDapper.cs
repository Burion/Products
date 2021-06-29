using DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;
using DataAccess.Attributes;
using System.Linq.Expressions;

namespace DataAccess.Infrastructure.Dapper
{
    public class DbAccesserDapper<T> : IDbAccesser<T>
    {
        public void AddItem(T item)
        {
            InsertItem(item);
        }

        public void DeleteItem(T item)
        {
            throw new NotImplementedException();
        }

        public void EditItem(T item)
        {
            throw new NotImplementedException();
        }

        public T GetItem(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public T GetItem(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetItems(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetItems()
        {
            throw new NotImplementedException();
        }

        void InsertItem(T item)
        {
            var connectionString = ConfigurationManager.AppSettings.Get("connectionString");

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var properties = typeof(T).GetProperties();
                var types = string.Join(", ", properties.Where(p => !Attribute.IsDefined(p, typeof(NotInsertable))).Select(p => p.Name));
                List<string> valuesList = new List<string>();

                foreach(var p in typeof(T).GetProperties())
                {
                    if(Attribute.IsDefined(item.GetType().GetProperty(p.Name), typeof(NotInsertable)))
                    {
                        continue;
                    }
                    var value = item.GetType().GetProperty(p.Name).GetValue(item, null);
                    if(item.GetType().GetProperty(p.Name).PropertyType == typeof(string))
                    {
                        valuesList.Add("'" + value + "'");
                    }
                    else
                    {
                        valuesList.Add(value.ToString());
                    }
                }

                string values = string.Join(',', valuesList);
                var tableName = Resources.Mapper.ResourceManager.GetString(typeof(T).Name);
                var query = $"insert into [productdb].[dbo].[{tableName}] ({types}) values ({values})";
                dbConnection.Query(query);
            }
        }
    }
}
