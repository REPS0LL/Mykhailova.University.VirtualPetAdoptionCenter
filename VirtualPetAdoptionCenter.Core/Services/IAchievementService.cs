using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models.DomainModels;
using VirtualPetAdoptionCenter.Models.Enums;

namespace VirtualPetAdoptionCenter.Core.Services
{
    public interface IAchievementService
    {
        Task CheckAndAddFeedAchievementAsync(int userId);
        Task CheckAndAddAdoptAchievementAsync(int userId);
        Task CheckAndAddEnvironmentAchievementAsync(int petId);
        AchievementModel GetAchivement(int userId);
    }
}
