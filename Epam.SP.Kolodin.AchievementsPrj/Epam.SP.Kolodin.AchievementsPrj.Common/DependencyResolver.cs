using Epam.SP.Kolodin.AchievementsPrj.DAL.Interface;
using Epam.SP.Kolodin.AchievementsPrj.MsSqlDAL;
using Epam.SP.Kolodin.AchievementsPrj.BLL.Interface;
using Epam.SP.Kolodin.AchievementsPrj.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.SP.Kolodin.AchievementsPrj.Common
{
    public class DependencyResolver
    {
        // знаю, что можно было бы воспользоваться Lazy<>, но не стал, ибо вдруг это не хорошо
        private static DependencyResolver _instance;
        public static DependencyResolver Instance => _instance ?? (_instance = new DependencyResolver());

        public IUserProfileDAO UserProfileDAO => new MsSqlUserProfileDAO();
        public IAchievementDAO AchievementDAO => new MsSqlAchievementDAO();

        public IUserProfileLogic UserProfileLogic => new UserProfileLogic(UserProfileDAO);
        public IAchievementLogic AchievementLogic => new AchievementLogic(AchievementDAO); 
    }
}
