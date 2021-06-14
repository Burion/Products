using Dapper;
using DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace DataAccess.Infrastructure.Dapper.Partial
{
    public class DbAccesserCategoryDapper
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        public void AddCategory(Category category)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"insert into [productdb].[dbo].[Categories] (Name) values ('{category.Name}')";
                dbConnection.Query(query);
            }
        }

        public void DeleteCategory(Category category)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"delete from [productdb].[dbo].[Categories] where Id = {category.Id}";
                dbConnection.Query(query);
            }
        }

        public void EditCategory(Category category)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"update [productdb].[dbo].[Categories] set Name = '{category.Name}' where Id = {category.Id}";
                dbConnection.Query(query);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"select * from [productdb].[dbo].[Categories]";
                return dbConnection.Query<Category>(query);
            }
        }

        public Category GetCategory(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"select * from [productdb].[dbo].[Categories] where Id = {id}";
                return dbConnection.QuerySingle<Category>(query);
            }
        }
    }
}
