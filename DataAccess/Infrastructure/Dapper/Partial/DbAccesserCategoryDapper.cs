using Dapper;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace DataAccess.Infrastructure.Dapper.Partial
{
    public class DbAccesserCategoryDapper : IDbAccesserCategory
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connectionString");

        public void AddCategory(Category category)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"insert into [productswpf].[dbo].[Categories] (Name) values ('{category.Name}')";
                dbConnection.Query(query);
            }
        }

        public void DeleteCategory(Category category)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"delete from [productswpf].[dbo].[Categories] where Id = {category.Id}";
                dbConnection.Query(query);
            }
        }

        public void EditCategory(Category category)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"update [productswpf].[dbo].[Categories] set Name = '{category.Name}' where Id = {category.Id}";
                dbConnection.Query(query);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"select * from [productswpf].[dbo].[Categories]";

                return dbConnection.Query<Category>(query);
            }
        }

        public Category GetCategory(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"select * from [productswpf].[dbo].[Categories] where Id = {id}";

                return dbConnection.QuerySingle<Category>(query);
            }
        }

        public Category GetCategoryByName(string name)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"select * from [productswpf].[dbo].[Categories] where Name = {name}";

                return dbConnection.QuerySingle<Category>(query);
            }
        }
    }
}
