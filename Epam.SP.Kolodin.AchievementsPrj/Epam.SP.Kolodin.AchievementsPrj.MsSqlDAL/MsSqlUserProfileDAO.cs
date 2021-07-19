using Epam.SP.Kolodin.AchievementsPrj.DAL.Interface;
using Epam.SP.Kolodin.AchievementsPrj.Entities;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Epam.SP.Kolodin.AchievementsPrj.MsSqlDAL
{
    public class MsSqlUserProfileDAO : IUserProfileDAO
    {
        // если подключаюсь к бд на домашнем компьютере
        //private string _connectionString = ConfigurationManager.ConnectionStrings["AchievementsPrjDBHome"].ConnectionString;

        // если подключаюсь к бд на рабочем компьютере
        //private string _connectionString = ConfigurationManager.ConnectionStrings["AchievementsPrjDBWorkPlace"].ConnectionString;
        private SqlConnection GetNewSqlConnection() => new SqlConnection(
            //ConfigurationManager.ConnectionStrings["AchievementsPrjDBWorkPlace"].ConnectionString);
            ConfigurationManager.ConnectionStrings["AchievementsPrjDBHome"].ConnectionString);

        private SqlConnection _connection;

        private void AddUserProfile(UserProfile userProfile, string login, byte[] password) => AddUserProfile(userProfile.Id, userProfile.FullName, userProfile.BirthDate, login, password);

        private void AddUserProfile(Guid id, string fullName, DateTime birthDate, string login, byte[] password)
        {
            using (_connection = GetNewSqlConnection())
            {
                string sqlProcedureName = "AddUserProfile";
                SqlCommand command = new SqlCommand(sqlProcedureName, _connection);
                command.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                command.Parameters.AddWithValue("@login", login);                
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@fullName", fullName);
                command.Parameters.AddWithValue("@birthDate", birthDate);
                command.ExecuteNonQuery();
            }
        }

        public UserProfile GetUserProfile(Guid id)
        {
            using (_connection = GetNewSqlConnection())
            {
                string sqlProcedureName = "GetUserProfile";
                SqlCommand command = new SqlCommand(sqlProcedureName, _connection);
                command.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new UserProfile(
                        id: id,
                        fullName: reader["full_name"] as string,
                        birthDate: (DateTime)reader["birth_date"]);
                }

                throw new InvalidOperationException("Cannot find UserProfile with GUID: " + id);
            }
        }
        public UserProfile GetUserProfile(string login, byte[] password)
        {
            using (_connection = GetNewSqlConnection())
            {
                string sqlProcedureName = "GetUserProfileByLogin";
                SqlCommand command = new SqlCommand(sqlProcedureName, _connection);
                command.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                command.Parameters.AddWithValue("@login", login);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    byte[] user_pass = (byte[])reader["user_pass"];

                    if (password.Length != user_pass.Length)
                    {
                        throw new InvalidConstraintException("Password is incorrect. (wrong size)");
                    }

                    for (int i = 0; i < user_pass.Length; i++)
                    {
                        if (password[i] != user_pass[i])
                        {
                            throw new InvalidConstraintException("Password is incorrect.");
                        }
                    }

                    return GetUserProfile((Guid)reader["user_id_pk"]);
                }

                
                throw new InvalidOperationException("Cannot find UserProfile with login: " + login);
            }
        }

        public UserProfile EditUserProfile(Guid id, string fullName, DateTime birthDate)
        {
            using (_connection = GetNewSqlConnection())
            {
                string sqlProcedureName = "EditUserProfile";
                SqlCommand command = new SqlCommand(sqlProcedureName, _connection);
                command.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@fullName", fullName);
                command.Parameters.AddWithValue("@birthDate", birthDate);
                command.ExecuteNonQuery();
            }
            return new UserProfile(id, fullName, birthDate);
        }

        public void RemoveUserProfile(Guid id)
        {
            using (_connection = GetNewSqlConnection())
            {
                string sqlProcedureName = "RemoveUserProfile";
                SqlCommand command = new SqlCommand(sqlProcedureName, _connection);
                command.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public UserProfile Registration(UserProfile userProfile, string login, byte[] password)
        { 
            AddUserProfile(userProfile, login, password);
            return GetUserProfile(userProfile.Id);
        }           
        
    }      
      
}
