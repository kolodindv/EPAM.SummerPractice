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
        void AddUserProfile(UserProfile userProfile);
        UserProfile ReadUserProfile(Guid id);
        void EditUserProfile(Guid id);
        void RemoveUserProfile(Guid id);
    }
}
