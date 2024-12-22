using Cafe_Management.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.Data_Access_Layer
{
    public class CategoryDataAccess : DataAccess
    {
        // Method to retrieve all categories
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                string sql = "SELECT * FROM Categories";
                using (SqlDataReader reader = this.GetData(sql))
                {
                    while (reader.Read())
                    {
                        Category category = new Category
                        {
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            CategoryName = reader["CategoryName"].ToString()
                        };
                        categories.Add(category);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                Console.WriteLine($"Error retrieving categories: {ex.Message}");
            }
            return categories;
        }

        // Method to retrieve a category by ID
        public Category GetCategoryById(int categoryId)
        {
            Category category = null;
            try
            {
                string sql = "SELECT * FROM Categories WHERE CategoryId = @CategoryId";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            category = new Category
                            {
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                CategoryName = reader["CategoryName"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                Console.WriteLine($"Error retrieving category by ID: {ex.Message}");
            }
            return category;
        }

        // Method to create a new category
        public bool CreateCategory(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                Console.WriteLine("Category name cannot be empty.");
                return false;
            }

            try
            {
                string sql = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                Console.WriteLine($"Error creating category: {ex.Message}");
                return false;
            }
        }

        // Method to update an existing category
        public bool UpdateCategory(int categoryId, string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                Console.WriteLine("Category name cannot be empty.");
                return false;
            }

            try
            {
                string sql = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                Console.WriteLine($"Error updating category: {ex.Message}");
                return false;
            }
        }

        // Method to delete a category by ID
        public bool DeleteCategory(int categoryId)
        {
            try
            {
                string sql = "DELETE FROM Categories WHERE CategoryId = @CategoryId";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                Console.WriteLine($"Error deleting category: {ex.Message}");
                return false;
            }
        }

        // Method to retrieve category names as a list of strings
        public List<string> GetCategoryNames()
        {
            List<string> categories = new List<string>();
            try
            {
                string sql = "SELECT CategoryName FROM Categories";
                using (SqlDataReader reader = this.GetData(sql))
                {
                    while (reader.Read())
                    {
                        categories.Add(reader["CategoryName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                Console.WriteLine($"Error retrieving category names: {ex.Message}");
            }
            return categories;
        }
        public Category GetCategoryByName(string categoryName)
        {
            string sql = "SELECT * FROM Categories WHERE CategoryName = @CategoryName";

            using (SqlCommand command = new SqlCommand(sql, this.connection))
            {
                command.Parameters.AddWithValue("@CategoryName", categoryName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Category category = new Category
                        {
                            CategoryId = (int)reader["CategoryId"],
                            CategoryName = reader["CategoryName"].ToString()
                        };
                        return category;
                    }
                }
            }

            return null;
        }

    }
}
