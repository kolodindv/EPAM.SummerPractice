using Epam.SP.Kolodin.AchievementsPrj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.SP.Kolodin.AchievementsPrj.DAL.Interface
{
    public interface IAchievementDAO
    {
        void AddAchievement(Achievement achievement);
        Achievement GetAchievement(Guid userId);
        List<Achievement> GetUserAchievements(Guid userId);
        Achievement EditAchievement(Guid id, string heading, string locationOfReceipt, int? degree, int? yearOfReceipt);
        void RemoveAchievement(Guid userId);
        List<Achievement> GetAchievementsByTitleLike(string like);
    }
}
