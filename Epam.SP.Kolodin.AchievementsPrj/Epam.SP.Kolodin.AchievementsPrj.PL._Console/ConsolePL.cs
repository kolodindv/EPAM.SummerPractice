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
        static private UserProfile Profile { set; get; }

        private static bool ConsoleСonfirmAction()
        {
            Console.WriteLine("Для подтверждения действия введите символ: \"Y\" или \"Д\"\n" +
                "Для отмены введите любой другой символ");
            char confirmChar = Console.ReadKey().KeyChar;

            switch (confirmChar)
            {
                case 'y': case 'д':
                case 'Y': case 'Д':
                    {
                        Console.WriteLine("\nПодтвержено\n");
                        return true;
                    }
                default:
                    {
                        Console.WriteLine("\nОтклонено\n");
                        return false;
                    }
            }
            
        }
        private static string ConsoleGetPassword()
        {
            Console.WriteLine("Придумайте пароль (до 32 символов):");
            string pass1 = Console.ReadLine();
            Console.WriteLine("Поворите пароль:");
            string pass2 = Console.ReadLine();

            if(pass1 == pass2)
            {
                return pass2;
            }
            else
            {
                Console.WriteLine("Пароли не совпадают");
                return null;
            }
        }        

        private static void UserProfileRegistration()
        {
            //как аналогичное????: Console.ReadLine("Полное имя: "); 
            //Добавление нового пользователя:
            //Полное имя: %вводимое имя%
            //Дата рождения (чч.мм.гггг): %вводимая дата%
            Console.WriteLine("Добавление нового пользователя:\n" +
                "Полное имя:");
            string fullName = Console.ReadLine();
            Console.WriteLine("Дата рождения (чч.мм.гггг):");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            UserProfile toAdd = new UserProfile(fullName, birthDate);
            Console.WriteLine("Введите логин нового пользователя: ");
            string login = Console.ReadLine();

            string pass = ConsoleGetPassword();

            while(pass == null)
            {
                Console.WriteLine("Повторите процедуру создания пароля:");
                pass = ConsoleGetPassword();
            }
            
            Console.WriteLine($"К добавлению подготовлен польователь:\n{toAdd}\n" +
                $"логин: {login}\n" +
                $"пароль: {pass}\n");

            if (ConsoleСonfirmAction())
            {
                //DependencyResolver.Instance.UserProfileLogic.Registration(toAdd, login, "fffrhrtyszx24231");
                DependencyResolver.Instance.UserProfileLogic.Registration(toAdd, login, pass);
                Console.WriteLine("Добавление нового пользователя успешно завершилось");
            }
            else
            {
                Console.WriteLine("Добавление нового пользователя было отменено");
                return;
            }

            Console.WriteLine("Желаете войти в созданный профиль?");
            if (ConsoleСonfirmAction())
            {
                UserAuthorization(login, pass);
                Console.WriteLine("Проифль успешно авторизован");
            }

        }

        private static void UserAuthorization(string login, string pass)
        {            
            Profile = DependencyResolver.Instance.UserProfileLogic.Authorization(login, pass);
        }
        private static void UserAuthorization()
        {
            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль:");
            string pass = Console.ReadLine();
            UserAuthorization(login, pass);
        }

        private static void ConsoleMenu()
        {
            Console.WriteLine("Консольный интерфейс DB Achievements:\n" +
                "Для продолжения введите номер действия\n" +
                "1. Авторизация\n" +
                "2. Регистрация\n" +
                "3. Выход\n");
            char number = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch(number)
            {
                case '1':
                    UserAuthorization();
                    break;
                case '2':
                    UserProfileRegistration();
                    break;
                case '3':
                    return;
                default:
                    throw new InvalidOperationException("Выбор операции произведен некорректно");

            }
            
            
        }
        static void Main(string[] args)
        {
            //RegistrationUserProfile("one");
            //RegistrationUserProfile("two");
            //RegistrationUserProfile("322");
            ////Console.WriteLine("Hello *** world!");

            //var upIn = new UserProfile("гроооомашик", DateTime.Parse("30.05.2000"));

            //DependencyResolver.Instance.UserProfileLogic.AddUserProfile(upIn);
            //DependencyResolver.Instance.UserProfileLogic.RemoveUserProfile(Guid.Parse("AE1B37DE-42DC-4688-8669-3DF037416641"));
            ////var upOut = DependencyResolver.Instance.UserProfileLogic.GetUserProfile(Guid.Parse("8CD06187-EBD6-41DE-92B2-6C4800FCFCB6"));
            ////Console.WriteLine(upOut);
            ///
            Console.WriteLine(Profile);
            ConsoleMenu();
            Console.WriteLine(Profile);

            //Console.WriteLine("Nice");
            Console.ReadLine();
        }
    }
}
