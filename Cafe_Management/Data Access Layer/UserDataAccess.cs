using Cafe_Management.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.Data_Access_Layer
{
    public class UserDataAccess : DataAccess
    {
        public bool UserRegister(User user)
        {
            try
            {
                string sql = "INSERT INTO Employees (Name, Username, Password, Email, DateOfBirth, Gender, PhoneNumber, UserType) " +
                             "VALUES (@Name, @Username, @Password, @Email, @DateOfBirth, @Gender, @PhoneNumber, @UserType)";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@UserType", user.UserType);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // Log exception (use a logging library or custom method)
                Console.WriteLine("Error during registration: " + ex.Message);
                return false;
            }
        }

        public string LoginValidation(string username, string password)
        {
            try
            {
                string sql = "SELECT UserType FROM Employees WHERE Username = @Username AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader["UserType"].ToString();
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine("Error during login validation: " + ex.Message);
                return null;
            }
        }

        public List<User> GetEmployee()
        {
            try
            {
                string sql = "SELECT * FROM Employees";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<User> users = new List<User>();

                    while (reader.Read())
                    {
                        User user = new User
                        {
                            EmployeeId = (int)reader["EmployeeId"],
                            Name = reader["Name"].ToString(),
                            Username = reader["Username"].ToString(),
                            DateOfBirth = reader["DateOfBirth"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            UserType = reader["UserType"].ToString(),
                            Password = reader["Password"].ToString()
                        };
                        users.Add(user);
                    }
                    return users;
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine("Error fetching employees: " + ex.Message);
                return new List<User>();
            }
        }

        public bool UpdateEmployee(int employeeId, string name, string username, string email, string phoneNumber, string gender, string userType, string password)
        {
            try
            {
                string sql = "UPDATE Employees SET Name = @Name, Username = @Username, Email = @Email, PhoneNumber = @PhoneNumber, " +
                             "Gender = @Gender, UserType = @UserType, Password = @Password WHERE EmployeeId = @EmployeeId";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@UserType", userType);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine("Error updating employee: " + ex.Message);
                return false;
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                string sql = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine("Error deleting employee: " + ex.Message);
                return false;
            }
        }

        public List<User> GetEmployeeByName(string name)
        {
            try
            {
                string sql = "SELECT * FROM Employees WHERE Name LIKE @Name";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", name + "%");

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<User> users = new List<User>();

                    while (reader.Read())
                    {
                        User user = new User
                        {
                            EmployeeId = (int)reader["EmployeeId"],
                            Name = reader["Name"].ToString(),
                            Username = reader["Username"].ToString(),
                            DateOfBirth = reader["DateOfBirth"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            UserType = reader["UserType"].ToString(),
                            Password = reader["Password"].ToString()
                        };
                        users.Add(user);
                    }
                    return users;
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine("Error fetching employees by name: " + ex.Message);
                return new List<User>();
            }
        }
    }
}
