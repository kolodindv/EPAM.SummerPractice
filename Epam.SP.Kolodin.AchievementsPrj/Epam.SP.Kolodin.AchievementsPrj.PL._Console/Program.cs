using Epam.SP.Kolodin.AchievementsPrj.Common;
using Epam.SP.Kolodin.AchievementsPrj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.SP.Kolodin.AchievementsPrj.PL._Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello *** world!");

            var upIn = new UserProfile("гроооомаш", DateTime.Parse("16.12.2000"));

            //DependencyResolver.Instance.UserProfileLogic.AddUserProfile(upIn);
            //DependencyResolver.Instance.UserProfileLogic.RemoveUserProfile(Guid.Parse("15F4CF7F-9985-4F3E-96DC-19BC50901F2D"));
            var upOut = DependencyResolver.Instance.UserProfileLogic.GetUserProfile(Guid.Parse("CCBA24E1-FFDD-47DC-AAD0-1E8531404163"));
            Console.WriteLine(upOut);

            Console.WriteLine("Nice");
            Console.ReadKey();
        }
    }
}
