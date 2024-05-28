using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models.DomainModels;
using VirtualPetAdoptionCenter.Models.Enums;

namespace VirtualPetAdoptionCenter.Core.Services
{
    public class PetService : IPetService
    {
        private readonly VirtualPetAdoptionCenterDbContext _dbContext;
        public PetService(VirtualPetAdoptionCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PetModel> GetAllPets()
        {
            return _dbContext.Pets.Where(x => x.UserId ==null).ToList();
        }
        public void AdoptPet(int petId, int userId)
        {
            var pet = _dbContext.Pets.FirstOrDefault(x => x.Id == petId);

            if (pet != null)
            {
                pet.UserId = userId;
                _dbContext.SaveChanges();
            }
        }
        public List<PetModel> GetPetsByUserId(int userId)
        {
            return _dbContext.Pets.Where(p => p.UserId == userId).ToList();
        }

        public PetModel GetPetById(int petId)
        {
            return _dbContext.Pets.FirstOrDefault(p => p.Id == petId);
        }
        
        public void UpdateGroomingTime(int petId, GroomType groomType)
        {
            var record = _dbContext.Groom.FirstOrDefault(x => x.PetId == petId);
            record ??= new GroomingModel();
            record.PetId = petId;

            switch (groomType)
            {
                case GroomType.TrimNailsTime:
                    record.TrimNailsTime = DateTime.Now;
                    break;
                case GroomType.WashTime:
                    record.WashTime = DateTime.Now;
                    break;
                case GroomType.BrushTime:
                    record.BrushTime = DateTime.Now;
                    break;
                case GroomType.FeedTime:
                    record.FeedTime = DateTime.Now;
                    break;
                default:
                    // 
                    break;
            }
            if (record.Id == 0)
            {
                _dbContext.Groom.Add(record);
            }
            _dbContext.SaveChanges();
        }

        public void SetEnvironment(int petId, PetEnvironmentType EnvironmentType)
        {
            var pet = _dbContext.Pets.FirstOrDefault(p => p.Id == petId);
            if (pet != null)
            {
                pet.EnvironmentType = EnvironmentType.ToString();
                _dbContext.SaveChanges();
            }          
        }

        public PetEnvironmentType GetEnvironment(int petId)
        {
            var pet = _dbContext.Pets.FirstOrDefault(p => p.Id == petId);
            if (pet != null && Enum.TryParse(pet.EnvironmentType, out PetEnvironmentType environmentType))
            {
                return environmentType;
            }
            return PetEnvironmentType.Home;
        }
     
    }
}
