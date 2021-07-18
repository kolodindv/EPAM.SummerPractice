using Epam.SP.Kolodin.AchievementsPrj.BLL.Interface;
using Epam.SP.Kolodin.AchievementsPrj.DAL.Interface;
using Epam.SP.Kolodin.AchievementsPrj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Epam.SP.Kolodin.AchievementsPrj.BLL
{
    public class UserProfileLogic : IUserProfileLogic
    {
        private IUserProfileDAO _userProfileDAO;

        public UserProfileLogic(IUserProfileDAO userProfileDAO)
        {
            _userProfileDAO = userProfileDAO;
        }

        public UserProfile Registration(UserProfile userProfile, string login, string password)
        {
           if (userProfile == null)
           {
                    throw new ArgumentNullException();
           }
            using (SHA512 shaM = new SHA512Managed())
            {
                byte[] pass_bytes = Encoding.ASCII.GetBytes(password);
                byte[] hash_pass = shaM.ComputeHash(pass_bytes); 
                return _userProfileDAO.Registration(userProfile, login, hash_pass);
            }
        }

        //public void AddUserProfile(UserProfile userProfile) => _userProfileDAO.AddUserProfile(userProfile);
        public UserProfile GetUserProfile(Guid id) => _userProfileDAO.GetUserProfile(id);
        public UserProfile EditUserProfile(Guid id, string fullName, DateTime birthDate) => _userProfileDAO.EditUserProfile(id, fullName, birthDate);
        //=> _userProfileDAO.EditUserProfile(id, fullName, birthDate);
        public void RemoveUserProfile(Guid id) => _userProfileDAO.RemoveUserProfile(id);
    }
}
