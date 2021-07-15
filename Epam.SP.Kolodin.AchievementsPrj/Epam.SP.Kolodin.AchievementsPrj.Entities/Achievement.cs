﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.SP.Kolodin.AchievementsPrj.Entities
{
    public class Achievement
    {
        public Achievement(Guid userId, string heading, string locationOfReceipt, int degree, int yearOfReceipt)
        {
            UserId = userId;
            Heading = heading;
            LocationOfReceipt = locationOfReceipt;
            Degree = degree;
            YearOfReceipt = yearOfReceipt;
        }

        public Guid UserId { get; }

        public string Heading { get; private set; }

        public string LocationOfReceipt { get; private set; }

        public int Degree { get; private set; }

        public int YearOfReceipt { get; private set; }

        public override string ToString() => JsonConvert.SerializeObject(this);        
    }
}
