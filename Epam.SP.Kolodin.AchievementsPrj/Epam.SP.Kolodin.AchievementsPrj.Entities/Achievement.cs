using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.SP.Kolodin.AchievementsPrj.Entities
{
    public class Achievement
    {
        public Achievement(Guid user_Id, string heading, string locationOfReceipt, int degree, int yearOfReceipt)
        {
            User_Id = user_Id;
            Heading = heading;
            LocationOfReceipt = locationOfReceipt;
            Degree = degree;
            YearOfReceipt = yearOfReceipt;
        }

        public Guid User_Id { get; }

        public string Heading { get; private set; }

        public string LocationOfReceipt { get; private set; }

        public int Degree { get; private set; }

        public int YearOfReceipt { get; private set; }
    }
}
