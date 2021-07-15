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

        private static string _connectionString = ConfigurationManager.ConnectionStrings["AchievementsPrjDB"].ConnectionString;
        private static SqlConnection _connection = new SqlConnection(_connectionString);
        public void AddUserProfile(UserProfile userProfile) => AddUserProfile(userProfile.Id, userProfile.FullName, userProfile.Age);

        public void AddUserProfile(Guid id, string fullName, int age)
        {
            using (_connection /*= GetNewSqlConnection()*/)
            {
                
            }

        public void EditUserProfile(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserProfile ReadUserProfile(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserProfile(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
