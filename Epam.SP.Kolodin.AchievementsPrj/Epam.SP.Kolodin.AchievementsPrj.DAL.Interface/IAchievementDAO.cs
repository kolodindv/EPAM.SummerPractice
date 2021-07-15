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
        Achievement EditAchievement(Guid userId);
        void RemoveAchievement(Guid userId);
    }
}
