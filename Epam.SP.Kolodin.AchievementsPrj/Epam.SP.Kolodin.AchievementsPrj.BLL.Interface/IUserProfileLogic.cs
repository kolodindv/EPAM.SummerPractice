﻿using Epam.SP.Kolodin.AchievementsPrj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.SP.Kolodin.AchievementsPrj.BLL.Interface
{
    public interface IUserProfileLogic
    {
        void AddUserProfile(UserProfile userProfile);
        UserProfile GetUserProfile(Guid id);
        UserProfile EditUserProfile(Guid id, string fullName, DateTime birthDate);
        void RemoveUserProfile(Guid id);
    }
}
