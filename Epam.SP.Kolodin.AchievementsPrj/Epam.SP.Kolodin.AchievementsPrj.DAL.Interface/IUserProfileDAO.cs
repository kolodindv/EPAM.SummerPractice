using Epam.SP.Kolodin.AchievementsPrj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.SP.Kolodin.AchievementsPrj.DAL.Interface
{
    public interface IUserProfileDAO
    {
        UserProfile Registration(UserProfile userProfile, string login, byte[] password);
        //void AddUserProfile(UserProfile userProfile);
        UserProfile GetUserProfile(Guid id);
        UserProfile EditUserProfile(Guid id, string fullName, DateTime birthDate);
        void RemoveUserProfile(Guid id);
    }
}
