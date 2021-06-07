using DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;
using DataAccess.Attrubutes;

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
                string types = string.Join(", ", typeof(T).GetProperties().Where(p => !Attribute.IsDefined(p, typeof(NotInsertable))).Select(p => p.Name));
                List<string> values = new List<string>();
                foreach(var p in typeof(T).GetProperties())
                {
                    if(Attribute.IsDefined(item.GetType().GetProperty(p.Name), typeof(NotInsertable)))
                    {
                        continue;
                    }
                    var value = item.GetType().GetProperty(p.Name).GetValue(item, null);
                    if(item.GetType().GetProperty(p.Name).PropertyType == typeof(string))
                    {
                        values.Add("'" + value + "'");
                    }
                    else
                    {
                        values.Add(value.ToString());
                    }
                }
                string valuesString = string.Join(',', values);
                
                var query = $"insert into [productdb].[dbo].[{Resources.Mapper.ResourceManager.GetString(typeof(T).Name)}] ({types}) values ({valuesString})";
                dbConnection.Query(query);

                //(typeof(T).Name)
            }
        }
    }
}
