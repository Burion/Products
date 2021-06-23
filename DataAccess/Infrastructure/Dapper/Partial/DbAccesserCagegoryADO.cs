using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace DataAccess.Infrastructure.Dapper.Partial
{
    public class DbAccesserCategoryADO : IDbAccesserCategory
    {
        string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        public void AddCategory(Category category)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"insert into [productswpf].[dbo].[Categories] (Name) values ('{category.Name}')";
                dbConnection.Open();
                SqlCommand command = new SqlCommand(query, dbConnection);
                command.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        public void DeleteCategory(Category category)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"delete from [productswpf].[dbo].[Categories] where Id = {category.Id}";
                dbConnection.Open();
                SqlCommand command = new SqlCommand(query, dbConnection);
                command.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        public void Dispose()
        {
            
        }

        public void EditCategory(Category category)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"update [productswpf].[dbo].[Categories] set Name = '{category.Name}' where Id = {category.Id}";
                dbConnection.Open();
                SqlCommand command = new SqlCommand(query, dbConnection);
                command.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"select * from [productswpf].[dbo].[Categories]";
                dbConnection.Open();
                SqlCommand command = new SqlCommand(query, dbConnection);
                var reader = command.ExecuteReader();
                List<Category> categories = new List<Category>();
                while(reader.Read())
                {
                    var c = new Category() { Id = (int)reader.GetValue(0), Name = (string)reader.GetValue(1) };
                    categories.Add(c);
                }
                dbConnection.Close();
                return categories;
            }
        }

        public Category GetCategory(int id)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                var query = $"select * from [productswpf].[dbo].[Categories] where Id = {id}";
                dbConnection.Open();
                SqlCommand command = new SqlCommand(query, dbConnection);
                var reader = command.ExecuteReader();
                var c = new Category() { Id = (int)reader.GetValue(0), Name = (string)reader.GetValue(1) };
                dbConnection.Close();
                return c;
            }
        }
    }
}
