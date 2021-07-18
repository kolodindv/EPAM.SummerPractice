using Epam.SP.Kolodin.AchievementsPrj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Epam.SP.Kolodin.AchievementsPrj.BLL.Interface
{
    public interface IUserProfileLogic
    {
        UserProfile Registration(UserProfile userProfile, string login, string password);
        //void AddUserProfile(UserProfile userProfile);
        UserProfile Authorization(string login, string password);
        UserProfile GetUserProfile(Guid id);
        UserProfile EditUserProfile(Guid id, string fullName, DateTime birthDate);
        void RemoveUserProfile(Guid id);
    }
}
