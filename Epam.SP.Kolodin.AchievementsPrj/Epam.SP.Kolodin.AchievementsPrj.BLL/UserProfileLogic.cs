using Epam.SP.Kolodin.AchievementsPrj.BLL.Interface;
using Epam.SP.Kolodin.AchievementsPrj.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.SP.Kolodin.AchievementsPrj.BLL
{
    public class UserProfileLogic : IUserProfileLogic
    {
        private IUserProfileDAO _userProfileDAO;

        public UserProfileLogic(IUserProfileDAO userProfileDAO)
        {
            _userProfileDAO = userProfileDAO;
        }
    }
}
