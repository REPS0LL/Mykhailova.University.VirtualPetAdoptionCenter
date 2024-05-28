using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models;
using VirtualPetAdoptionCenter.Models.DomainModels;
using VirtualPetAdoptionCenter.Models.NewFolder1;

namespace VirtualPetAdoptionCenter.Core.Services
{
    public class GroomService : IGroomService
    {
        private readonly VirtualPetAdoptionCenterDbContext _dbContext;
        private readonly IEmailService _emailService;
        private readonly IAccountService _accountService;

        public GroomService(VirtualPetAdoptionCenterDbContext dbContext, IEmailService emailService, IAccountService accountService)
        {
            _dbContext = dbContext;
            _emailService = emailService;
            _accountService = accountService;
        }

        public PetConditionModel CheckPetCondition(int petId)
        {
            var petCondition = new PetConditionModel();
            var record = _dbContext.Groom.FirstOrDefault(g => g.PetId == petId);

            if (record != null && (DateTime.Now - record.WashTime).TotalHours <= 2)
            {
                petCondition.IsWashed = true;
            }
            else
            {
                petCondition.IsWashed = false;
            }

            if (record != null && (DateTime.Now - record.TrimNailsTime).TotalHours <= 2)
            {
                petCondition.IsNailTrimmed = true;
            }
            else
            {
                petCondition.IsNailTrimmed = false;
            }

            if (record != null && (DateTime.Now - record.BrushTime).TotalHours <= 2)
            {
                petCondition.IsBrushed = true;
            }
            else
            {
                petCondition.IsBrushed = false;
            }

            if (record != null && (DateTime.Now - record.FeedTime).TotalHours <= 2)
            {
                petCondition.IsFeed = true;
            }
            else
            {
                petCondition.IsFeed = false;
            }

            return petCondition;
        }
    }
}
