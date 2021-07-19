using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.SP.Kolodin.AchievementsPrj.Entities
{
    public class Achievement
    {
        public Achievement(Guid id, Guid userId, string heading, string locationOfReceipt, int? degree, int? yearOfReceipt)
        {
            Id = id;
            UserId = userId;
            Heading = heading;
            LocationOfReceipt = locationOfReceipt;
            Degree = degree;
            YearOfReceipt = yearOfReceipt;
        }
        public Achievement(Guid userId, string heading, string locationOfReceipt, int? degree, int? yearOfReceipt) :
            this(Guid.NewGuid(), userId, heading, locationOfReceipt, degree, yearOfReceipt) { }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }

        public string Heading { get; set; }

        public string LocationOfReceipt { get; set; }

        public int? Degree { get; set; }

        public int? YearOfReceipt { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);        
    }
}
