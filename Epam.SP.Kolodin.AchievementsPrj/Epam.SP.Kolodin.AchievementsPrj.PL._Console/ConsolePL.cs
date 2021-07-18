using Epam.SP.Kolodin.AchievementsPrj.Common;
using Epam.SP.Kolodin.AchievementsPrj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.SP.Kolodin.AchievementsPrj.PL._Console
{
    class ConsolePL
    {
        private static bool ConsoleСonfirmAction()
        {
            Console.WriteLine("Для подтверждения действия введите символ: \"Y\" или \"Д\"\n" +
                "Для отмены введите любой другой символ");
            char confirmChar = Console.ReadKey().KeyChar;
            switch (confirmChar)
            {
                case 'Y': case 'Д':
                    {
                        Console.WriteLine("Подтвержено\n");
                        return true;
                    }
                default:
                    {
                        Console.WriteLine("Отклонено\n");
                        return false;
                    }
            }
            
        }
        public static void AddUserProfile()
        {

            //как аналогичное: Console.ReadLine("Полное имя: "); 
            //Добавление нового пользователя:
            //Полное имя: %вводимое имя%
            //Дата рождения (чч.мм.гггг): %вводимая дата%
            Console.WriteLine("Добавление нового пользователя:\n" +
                "Полное имя:");
            string fullName = Console.ReadLine();
            Console.WriteLine("Дата рождения (чч.мм.гггг):");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            UserProfile toAdd = new UserProfile(fullName, birthDate);
            Console.WriteLine($"К добавлению подготовлен польователь:\n{toAdd}");

            if(ConsoleСonfirmAction())
            {
                DependencyResolver.Instance.UserProfileLogic.AddUserProfile(toAdd);
                Console.WriteLine("Добавление нового пользователя успешно завершилось");
            }
            else
            {
                Console.WriteLine("Добавление нового пользователя было отменено");
                return;
            }

        }
        static void Main(string[] args)
        {
            AddUserProfile();
            ////Console.WriteLine("Hello *** world!");

            //var upIn = new UserProfile("гроооомашик", DateTime.Parse("30.05.2000"));

            //DependencyResolver.Instance.UserProfileLogic.AddUserProfile(upIn);
            ////DependencyResolver.Instance.UserProfileLogic.RemoveUserProfile(Guid.Parse("8CD06187-EBD6-41DE-92B2-6C4800FCFCB6"));
            ////var upOut = DependencyResolver.Instance.UserProfileLogic.GetUserProfile(Guid.Parse("8CD06187-EBD6-41DE-92B2-6C4800FCFCB6"));
            ////Console.WriteLine(upOut);

            Console.WriteLine("Nice");
            Console.ReadLine();
        }
    }
}
