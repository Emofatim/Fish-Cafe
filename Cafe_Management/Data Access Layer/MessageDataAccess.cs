using Cafe_Management.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cafe_Management.Data_Access_Layer
{
    class MessageDataAccess : DataAccess
    {
        public bool MessageReceiverValidation(string username)
        {
            string sql = "SELECT COUNT(*) FROM Employees WHERE Username = @Username";
            try
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // Log exception or handle it as necessary
                throw new Exception("Error validating message receiver.", ex);
            }
        }

        public List<Message> GetEmployeeMessage(string username)
        {
            string sql = "SELECT Receiver, Sender, Message FROM EmployeeMessages WHERE Receiver = @Receiver";
            var messages = new List<Message>();

            try
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Receiver", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            messages.Add(new Message
                            {
                                Receiver = reader["Receiver"].ToString(),
                                Sender = reader["Sender"].ToString(),
                                Messages = reader["Message"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception or handle it as necessary
                throw new Exception("Error retrieving employee messages.", ex);
            }

            return messages;
        }

        public List<Message> GetAdminMessages(string username)
        {
            string sql = "SELECT Sender, Receiver, Message FROM AdminMessages WHERE Receiver = @Receiver";
            var messages = new List<Message>();

            try
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Receiver", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            messages.Add(new Message
                            {
                                Sender = reader["Sender"].ToString(),
                                Receiver = reader["Receiver"].ToString(),
                                Messages = reader["Message"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception or handle it as necessary
                throw new Exception("Error retrieving admin messages.", ex);
            }

            return messages;
        }

        public bool SentMessageToEmployee(Message message)
        {
            string sql = "INSERT INTO AdminMessages (Receiver, Sender, Message) VALUES (@Receiver, @Sender, @Message)";
            return ExecuteNonQuery(sql, message);
        }

        public bool SendMessageToAdmin(Message message)
        {
            string sql = "INSERT INTO EmployeeMessages (Receiver, Sender, Message) VALUES (@Receiver, @Sender, @Message)";
            return ExecuteNonQuery(sql, message);
        }

        private bool ExecuteNonQuery(string sql, Message message)
        {
            try
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Receiver", message.Receiver);
                    command.Parameters.AddWithValue("@Sender", message.Sender);
                    command.Parameters.AddWithValue("@Message", message.Messages);

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // Log exception or handle it as necessary
                throw new Exception("Error sending message.", ex);
            }
        }
    }
}