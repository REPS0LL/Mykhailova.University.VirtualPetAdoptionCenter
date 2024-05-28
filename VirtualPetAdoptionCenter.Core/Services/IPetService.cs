using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using VirtualPetAdoptionCenter.Models.Enums;
using VirtualPetAdoptionCenter.Models.DomainModels;

namespace VirtualPetAdoptionCenter.Core.Services
{
    public interface IPetService
    {
        List<PetModel> GetAllPets();
        void AdoptPet(int petId, int userId);
        List<PetModel> GetPetsByUserId(int userId);
        PetModel GetPetById(int petId);
        void UpdateGroomingTime(int petId, GroomType groomType);
        void SetEnvironment(int petId, PetEnvironmentType EnvironmentType);
        PetEnvironmentType GetEnvironment(int petId);
    }
}
