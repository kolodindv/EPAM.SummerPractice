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
    public class UserProfileLogic : IUserProfileLogic
    {
        private IUserProfileDAO _userProfileDAO;

        public UserProfileLogic(IUserProfileDAO userProfileDAO)
        {
            _userProfileDAO = userProfileDAO;
        }

        public void AddUserProfile(UserProfile userProfile) => _userProfileDAO.AddUserProfile(userProfile);
        public UserProfile GetUserProfile(Guid id) => _userProfileDAO.GetUserProfile(id);
        public UserProfile EditUserProfile(Guid id) => _userProfileDAO.EditUserProfile(id);
        public void RemoveUserProfile(Guid id) => _userProfileDAO.RemoveUserProfile(id);
    }
}
