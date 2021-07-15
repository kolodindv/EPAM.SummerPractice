using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.SP.Kolodin.AchievementsPrj.Entities
{
    public class UserProfile
    {
        public UserProfile(Guid id, string fullName, DateTime birthDate)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
        }
        public UserProfile(string fullName, DateTime birthDate) : this(Guid.NewGuid(), fullName, birthDate) { }        
       
        public Guid Id { get; }
        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
