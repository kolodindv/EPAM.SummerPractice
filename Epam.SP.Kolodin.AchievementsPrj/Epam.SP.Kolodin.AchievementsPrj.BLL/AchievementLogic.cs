using Epam.SP.Kolodin.AchievementsPrj.BLL.Interface;
using Epam.SP.Kolodin.AchievementsPrj.DAL.Interface;
using Epam.SP.Kolodin.AchievementsPrj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.SP.Kolodin.AchievementsPrj.BLL
{
    public class AchievementLogic : IAchievementLogic
    {
        private IAchievementDAO _achievementDAO;
        public AchievementLogic (IAchievementDAO achievementDAO)
        {
            _achievementDAO = achievementDAO;
        }

        public void AddAchievement(Achievement achievement) => _achievementDAO.AddAchievement(achievement);
        public List<Achievement> GetUserAchievements(Guid userId) => _achievementDAO.GetUserAchievements(userId);
        public Achievement GetAchievement(Guid userId) => _achievementDAO.GetAchievement(userId);
        public Achievement EditAchievement(Guid id, string heading, string locationOfReceipt, int? degree, int? yearOfReceipt) => 
            _achievementDAO.EditAchievement(id, heading, locationOfReceipt, degree, yearOfReceipt);
        public void RemoveAchievement(Guid userId) => _achievementDAO.RemoveAchievement(userId);
    }
}

