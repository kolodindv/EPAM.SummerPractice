﻿using Epam.SP.Kolodin.AchievementsPrj.DAL.Interface;
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

        public void AddUserProfile(UserProfile userProfile) => AddUserProfile(userProfile.Id, userProfile.FullName, userProfile.BirthDate);

        private void AddUserProfile(Guid id, string fullName, DateTime birthDate)
        {
            using (_connection = GetNewSqlConnection())
            {
                string sqlProcedureName = "AddUserProfile";
                SqlCommand command = new SqlCommand(sqlProcedureName, _connection);
                command.CommandType = CommandType.StoredProcedure;

                _connection.Open();
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
    }
}
