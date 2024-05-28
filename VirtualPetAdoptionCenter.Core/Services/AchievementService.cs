using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualPetAdoptionCenter.Models.DomainModels;
using VirtualPetAdoptionCenter.Models.Enums;

namespace VirtualPetAdoptionCenter.Core.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly VirtualPetAdoptionCenterDbContext _dbContext;
        public AchievementService(VirtualPetAdoptionCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CheckAndAddFeedAchievementAsync(int userId)
        {
            var hasFeedingRecords = await _dbContext.Pets
                .AnyAsync(p => p.UserId == userId);

            if (hasFeedingRecords)
            {
                var existingAchievement = await _dbContext.Achievements.FirstOrDefaultAsync(u => u.UserId == userId);

                if (existingAchievement == null)
                {
                    var achievement = new AchievementModel
                    {
                        UserId = userId,
                        Feed = 1
                    };
                    try
                    {
                        _dbContext.Achievements.Add(achievement);
                        await _dbContext.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
                else
                {
                    existingAchievement.Feed = 1;
                    await _dbContext.SaveChangesAsync();
                }
            }           
        }

        public async Task CheckAndAddAdoptAchievementAsync(int userId)
        {
            var adoptCount = await _dbContext.Pets
                .Where(p => p.UserId == userId)
                .CountAsync();

            if (adoptCount == 1)
            {
                var existingAchievement = await _dbContext.Achievements.FirstOrDefaultAsync(u => u.UserId == userId);

                if (existingAchievement == null)
                {
                    var achievement = new AchievementModel
                    {
                        UserId = userId,
                        Adopt = 1
                    };
                    try
                    {
                        _dbContext.Achievements.Add(achievement);
                        await _dbContext.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                else
                {
                    existingAchievement.Adopt = 1;
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
           
        public async Task CheckAndAddEnvironmentAchievementAsync(int petId)
        {
            var pet = _dbContext.Pets.FirstOrDefault(x => x.Id == petId);

            var existingAchievement = await _dbContext.Achievements.FirstOrDefaultAsync(u => u.UserId == pet.UserId);

            if (existingAchievement == null)
            {
                var achievement = new AchievementModel
                {
                    UserId = pet.UserId.Value,
                    Environment = 1
                };
                try
                {
                    _dbContext.Achievements.Add(achievement);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
            else
            {
                existingAchievement.Environment = 1;
                await _dbContext.SaveChangesAsync();
            }

        }

        public AchievementModel GetAchivement(int userId)
        {
            var achievement = _dbContext.Achievements.FirstOrDefault(a => a.UserId == userId);
            return achievement;
        }
    }
}           