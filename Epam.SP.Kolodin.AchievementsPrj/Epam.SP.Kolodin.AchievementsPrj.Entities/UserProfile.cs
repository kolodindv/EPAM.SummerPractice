using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.SP.Kolodin.AchievementsPrj.Entities
{
    public class UserProfile
    {
        public UserProfile(string fullName, int age)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Age = age;
        }

        public Guid Id { get; }
        public string FullName { get; private set; }
        public int Age { get; private set; }
    }
}
