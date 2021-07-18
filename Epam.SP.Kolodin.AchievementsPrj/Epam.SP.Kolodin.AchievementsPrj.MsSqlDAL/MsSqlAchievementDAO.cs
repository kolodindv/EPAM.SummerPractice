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
    public class MsSqlAchievementDAO : IAchievementDAO
    {
        // если подключаюсь к бд на домашнем компьютере
        //private string _connectionString = ConfigurationManager.ConnectionStrings["AchievementsPrjDBHome"].ConnectionString;

        // если подключаюсь к бд на рабочем компьютере
        //private string _connectionString = ConfigurationManager.ConnectionStrings["AchievementsPrjDBWorkPlace"].ConnectionString;
        private SqlConnection GetNewSqlConnection() => new SqlConnection(
            //ConfigurationManager.ConnectionStrings["AchievementsPrjDBWorkPlace"].ConnectionString);
            ConfigurationManager.ConnectionStrings["AchievementsPrjDBHome"].ConnectionString);
        private SqlConnection _connection;

        public void AddAchievement(Achievement achievement) => AddAchievement(achievement.Id, achievement.UserId,
            achievement.Heading, achievement.LocationOfReceipt, achievement.Degree, achievement.YearOfReceipt);

        private void AddAchievement(Guid id, Guid userId, string heading, string locationOfReceipt, int degree, int yearOfReceipt)
        {
            using (_connection = GetNewSqlConnection())
            {
                string sqlProcedureName = "AddUserProfile";
                SqlCommand command = new SqlCommand(sqlProcedureName, _connection);
                command.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@heading", heading);
                command.Parameters.AddWithValue("@locationOfReceipt", locationOfReceipt);
                command.Parameters.AddWithValue("@degree", degree);
                command.Parameters.AddWithValue("@yearOfReceipt", yearOfReceipt);
                command.ExecuteNonQuery();
            }
        }

        public Achievement EditAchievement(Guid id, string heading, string locationOfReceipt, int degree, int yearOfReceipt)
        {
            using (_connection = GetNewSqlConnection())
            {
                string sqlProcedureName = "EditAchievement";
                SqlCommand command = new SqlCommand(sqlProcedureName, _connection);
                command.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@heading", heading);
                command.Parameters.AddWithValue("@locationOfReceipt", locationOfReceipt);
                command.Parameters.AddWithValue("@degree", degree);
                command.Parameters.AddWithValue("@yearOfReceipt", yearOfReceipt);
                command.ExecuteNonQuery();
            }
            return new Achievement(id, heading, locationOfReceipt, degree, yearOfReceipt);
        }

        public Achievement GetAchievement(Guid id)
        {
            using (_connection = GetNewSqlConnection())
            {
                string sqlProcedureName = "GetAchievement";
                SqlCommand command = new SqlCommand(sqlProcedureName, _connection);
                command.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Achievement(
                        id: id,
                        userId: (Guid)reader["user_id_pk_fk"],
                        heading: reader["heading"] as string,
                        locationOfReceipt: reader["location_of_receipt"] as string, 
                        degree: (int)reader["degree"], 
                        yearOfReceipt: (int)reader["year_of_receipt"]);
                    }

                throw new InvalidOperationException("Cannot find Achievement with GUID: " + id);
            }
        }

        public List<Achievement> GetUserAchievements(Guid userId)
        {
            using (_connection = GetNewSqlConnection())
            {
                string sqlProcedureName = "GetUserAchievements";
                SqlCommand command = new SqlCommand(sqlProcedureName, _connection);
                command.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                command.Parameters.AddWithValue("@id", userId);

                SqlDataReader reader = command.ExecuteReader();

                List<Achievement> userAchievements = new List<Achievement>();

                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userAchievements.Add(new Achievement(
                            id: (Guid)reader["id_pk"],
                            userId: userId,
                            heading: reader["heading"] as string,
                            locationOfReceipt: reader["location_of_receipt"] as string,
                            degree: (int)reader["degree"],
                            yearOfReceipt: (int)reader["year_of_receipt"]));

                    }
                    return userAchievements;
                }                
                else
                {
                    throw new InvalidOperationException("Cannot find UserProfile with GUID: " + userId);
                } 
            }
        }

        public void RemoveAchievement(Guid id)
        {
            using (_connection = GetNewSqlConnection())
            {
                string sqlProcedureName = "RemoveAchievement";
                SqlCommand command = new SqlCommand(sqlProcedureName, _connection);
                command.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
