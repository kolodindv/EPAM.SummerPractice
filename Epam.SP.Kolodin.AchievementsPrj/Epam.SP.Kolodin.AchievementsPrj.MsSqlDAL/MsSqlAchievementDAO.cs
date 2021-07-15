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
        //private static string _connectionString = ConfigurationManager.ConnectionStrings["AchievementsPrjDBHome"].ConnectionString;

        // если подключаюсь к бд на рабочем компьютере
        private static string _connectionString = ConfigurationManager.ConnectionStrings["AchievementsPrjDBWorkPlace"].ConnectionString;

        public void AddAchievement(Achievement achievement)
        {
            throw new NotImplementedException();
        }

        public Achievement EditAchievement(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Achievement GetAchievement(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAchievement(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
