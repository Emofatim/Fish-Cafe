using Cafe_Management.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cafe_Management.Data_Access_Layer
{
    class CustomerDataAccess : DataAccess
    {
       
        // Retrieves all customers from the database.

        public List<Customer> GetCustomer()
        {
            const string query = "SELECT * FROM Customers";
            List<Customer> customers = new List<Customer>();

            try
            {
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(CreateCustomerFromReader(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error fetching customers: {ex.Message}");
            }

            return customers;
        }

        
        // Retrieves customers whose names match the specified prefix.
        
        public List<Customer> GetCustomerByName(string namePrefix)
        {
            const string query = "SELECT * FROM Customers WHERE Name LIKE @NamePrefix";
            List<Customer> customers = new List<Customer>();

            try
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NamePrefix", namePrefix + "%");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(CreateCustomerFromReader(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error fetching customers by name: {ex.Message}");
            }

            return customers;
        }
 
        // Adds a new customer to the database.
        // </summary>
        
        public bool AddCustomer(string customerName, string phoneNumber)
        {
            const string query = "INSERT INTO Customers (Name, PhoneNumber) VALUES (@Name, @PhoneNumber)";

            try
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", customerName);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error adding customer: {ex.Message}");
                return false;
            }
        }

        
        // Helper method to create a Customer object from a SqlDataReader.
       
        private Customer CreateCustomerFromReader(SqlDataReader reader)
        {
            return new Customer
            {
                Name = reader["Name"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString()
            };
        }
    }
}
