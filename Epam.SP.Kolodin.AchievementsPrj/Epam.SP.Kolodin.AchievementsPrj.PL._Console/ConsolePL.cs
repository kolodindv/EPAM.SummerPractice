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
        private static UserProfile Profile { get; set; }
        private static List<Achievement> Achievements { get; set; }

        private static void ShowAchievements()
        {
            Console.WriteLine(Profile);
            int i = 0;
            foreach (Achievement ach in Achievements)
            {
                Console.WriteLine($"{i}: {ach}");
                i++;
            }
        }
        private static Guid GetAchievementIdByListNomber(int number) => Achievements[number].Id;
        private static int GetAchievementNomber()
        {
            ShowAchievements();
            Console.WriteLine("Введите номер достижения для работы с ним");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

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
                Profile = DependencyResolver.Instance.UserProfileLogic.Registration(toAdd, login, pass);
                Console.WriteLine("Добавление нового пользователя успешно завершилось");
            }
            else
            {
                Console.WriteLine("Добавление нового пользователя было отменено");
                return;
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

        private static void GetUserProfile()
        {
            Profile = DependencyResolver.Instance.UserProfileLogic.GetUserProfile(Profile.Id);
        }
        private static void EditUserProfile()
        {
            Console.WriteLine(Profile);
            Console.WriteLine("Изменить полное имя?");
            if(ConsoleСonfirmAction())
            {
                Console.WriteLine("Введите новое полное имя:");
                string fullName = Console.ReadLine();
                Profile.FullName = fullName;
            }
            Console.WriteLine(Profile);
            Console.WriteLine("Изменить дату рождения?");
            if (ConsoleСonfirmAction())
            {
                Console.WriteLine("Введите новую дату (дд.мм.гггг):");
                DateTime birthDate = DateTime.Parse(Console.ReadLine());
                Profile.BirthDate = birthDate;

            }
            DependencyResolver.Instance.UserProfileLogic.EditUserProfile(Profile.Id, Profile.FullName, Profile.BirthDate);
            // не уверен зачем, но давайте будем считать что периодическое обновление от сервера нам требуется, а значит произойдет 
            // внеочередное подтягивание профиля из бд
            GetUserProfile();
            Console.WriteLine(Profile);

        }
        private static void RemoveUserProfile()
        {
            Console.WriteLine("Вы уверены, что хотите УДАЛИТЬ профиль?");
            if (ConsoleСonfirmAction())
            {
                DependencyResolver.Instance.UserProfileLogic.RemoveUserProfile(Profile.Id);
                Profile = null;
            }            
        }

        private static void GetUserAchievements()
        {
            Achievements = DependencyResolver.Instance.AchievementLogic.GetUserAchievements(Profile.Id);
        }
        private static void AddUserAchievement()
        {
            Console.WriteLine("Добавление нового достижения:\n" +
                "Название/заголовок:");
            string heading = Console.ReadLine();
            if (heading == "")
            {
                heading = null;
            }
            Console.WriteLine("Место/локация получения (при отсутствии - пропустить):");
            string locationOfReceipt = Console.ReadLine();
            if (locationOfReceipt == "")
            {
                locationOfReceipt = null;
            }
            Console.WriteLine("Место/степень/этап (при отсутствии - пропустить):");
            int? degree;
            try
            {
                degree = int.Parse(Console.ReadLine());
            }
            catch
            {
                degree = null; 
            }
          
            Console.WriteLine("Год получения (при отсутствии - пропустить):");
            int? yearOfReceipt;
            try
            {
                yearOfReceipt = int.Parse(Console.ReadLine());
            }
            catch
            {
                yearOfReceipt = null;
            }

            Achievement toAdd = new Achievement(Profile.Id, heading, locationOfReceipt, degree, yearOfReceipt);

            Console.WriteLine($"К добавлению подготовлено достижение:\n{toAdd}\n");
            if (ConsoleСonfirmAction())
            {
                DependencyResolver.Instance.AchievementLogic.AddAchievement(toAdd);                
                Console.WriteLine("Добавление нового достижения успешно завершилось");
                GetUserAchievements();
            }
            else
            {
                Console.WriteLine("Добавление нового достижения было отменено");
                return;
            }
        }
        private static void EditUserAchievement()
        {
            int number = GetAchievementNomber();
            Guid achId = GetAchievementIdByListNomber(number);
            string heading = Achievements[number].Heading;
            string locationOfReceipt = Achievements[number].LocationOfReceipt;
            int? degree = Achievements[number].Degree;
            int? yearOfReceipt = Achievements[number].YearOfReceipt;

            Console.WriteLine(Achievements[number]);
            Console.WriteLine("Изменить название/заголовок ?");
            if (ConsoleСonfirmAction())
            {
                Console.WriteLine("Введите новое название/заголовок:");
                heading = Console.ReadLine();
                if (heading == "")
                {
                    heading = null;
                }
            }
            Console.WriteLine(Achievements[number]);
            Console.WriteLine("Изменить место/локацию получения (при отсутствии - пустая строка) ?");
            if (ConsoleСonfirmAction())
            {
                Console.WriteLine("Введите место/локацию получения:");
                locationOfReceipt = Console.ReadLine();
                if (locationOfReceipt == "")
                {
                    locationOfReceipt = null;
                }

            }
            Console.WriteLine(Achievements[number]);
            Console.WriteLine("Изменить место/степень/этап (при отсутствии - пустая строка) ?");
            if (ConsoleСonfirmAction())
            {
                Console.WriteLine("Введите новое место/степень/этап:");
                degree = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(Achievements[number]);
            Console.WriteLine("Изменить год получения (при отсутствии - пустая строка) ?");
            if (ConsoleСonfirmAction())
            {
                Console.WriteLine("Введите новый год получения:");
                yearOfReceipt = int.Parse(Console.ReadLine());
            }

            DependencyResolver.Instance.AchievementLogic.EditAchievement(achId, heading, locationOfReceipt, degree, yearOfReceipt);
            Console.WriteLine(DependencyResolver.Instance.AchievementLogic.GetAchievement(achId));            
        }
        private static void RemoveUserAchievement()
        {
            int number = GetAchievementNomber();
            Console.WriteLine("Вы уверены, что хотите УДАЛИТЬ достижение?");
            if (ConsoleСonfirmAction())
            {
                DependencyResolver.Instance.AchievementLogic.RemoveAchievement(GetAchievementIdByListNomber(number));
                GetUserAchievements();
                ShowAchievements();
            }
        }


        private static bool AchievementsMenu()
        {
            if (Profile == null)
            {
                Console.WriteLine("Вы неавторизованы!");
                return false;
            }

            Console.WriteLine("Интерфейс Ваших достижений DB Achievements:\n" +
            "Для продолжения введите номер действия\n" +
                "1. Обновление и просмотр списка достижений\n" +
                "2. Добавление нового достижения\n" +
                "3. Изменение выбранного достижения\n" +
                "4. Удаление выбранного достижения\n" +
                "5. Выход\n");

            char number = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (number)
            {
                case '1':
                    GetUserAchievements();
                    ShowAchievements();
                    return true;
                case '2':
                    AddUserAchievement();
                    return true;
                case '3':
                    EditUserAchievement();
                    return true;
                case '4':
                    RemoveUserAchievement();
                    return true;
                case '5':
                    return false;
                default:
                    throw new InvalidOperationException("Выбор операции произведен некорректно");
            }

        }
        private static bool ProfileMenu()
        {
            if(Profile == null)
            {
                Console.WriteLine("Вы неавторизованы!");
                return false;
            }
            Console.WriteLine("Интерфейс Вашего профиля DB Achievements:\n" +
            "Для продолжения введите номер действия\n" +
                "1. Обновление и просмотр профиля\n" +
                "2. Изменение профиля\n" +
                "3. Удаление профиля\n" +
                "4. Операции в меню ваших достижений\n" +
                "5. Выход\n");
            char number = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (number)
            {
                case '1':
                    GetUserProfile();
                    Console.WriteLine(Profile);
                    return true;
                case '2':
                    EditUserProfile();
                    return true;
                case '3':
                    RemoveUserProfile();
                    return true;
                case '4':
                    bool stopFlag = true;
                    while (stopFlag)
                    {
                        stopFlag = AchievementsMenu();
                    }
                    return true;
                case '5':
                    return false;
                default:
                    throw new InvalidOperationException("Выбор операции произведен некорректно");

            }
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
                    Console.WriteLine(Profile);
                    bool stopFlag1 = true; 
                    while (stopFlag1)
                    {
                        stopFlag1 = ProfileMenu();
                    }
                    break;
                case '2':
                    UserProfileRegistration();
                    Console.WriteLine(Profile);
                    bool stopFlag2 = true;
                    while (stopFlag2)
                    {
                        stopFlag2 = ProfileMenu();
                    }
                    break;
                case '3':
                    return;
                default:
                    throw new InvalidOperationException("Выбор операции произведен некорректно");

            }
            
            
        }

        static void Main(string[] args)
        {            
            ConsoleMenu();
        }
    }
}
