using Epam.SP.Kolodin.AchievementsPrj.BLL.Interface;
using Epam.SP.Kolodin.AchievementsPrj.DAL.Interface;
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
    }
}
