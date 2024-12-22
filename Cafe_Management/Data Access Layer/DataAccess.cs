using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Cafe_Management.Data_Access_Layer
{
    public class DataAccess : IDisposable
    {
        public readonly SqlConnection connection;
        public SqlCommand _command;

        // Constructor to initialize the connection
        public DataAccess()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Cafe_Management"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not configured properly.");
            }

            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to connect to the database.", ex);
            }
        }

        // Method to execute a SQL query and return data
        public SqlDataReader GetData(string sql)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentException("SQL query cannot be null or empty.", nameof(sql));
            }

            try
            {
                _command = new SqlCommand(sql, connection);
                return _command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("Error executing SQL query.", ex);
            }
        }

        // Method to execute a SQL command that does not return data (e.g., INSERT, UPDATE, DELETE)
        public int ExecuteQuery(string sql)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentException("SQL query cannot be null or empty.", nameof(sql));
            }

            try
            {
                _command = new SqlCommand(sql, connection);
                return _command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("Error executing SQL command.", ex);
            }
        }

        // Dispose method to clean up resources (close the connection)
        public void Dispose()
        {
            try
            {
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error closing the database connection.", ex);
            }
        }
    }

    // Custom exception for data access errors
    public class DataAccessException : Exception
    {
        public DataAccessException(string message) : base(message) { }

        public DataAccessException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
