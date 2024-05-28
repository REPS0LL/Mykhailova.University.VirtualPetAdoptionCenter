using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models.DomainModels;

namespace VirtualPetAdoptionCenter.Core.Services
{
    public interface IGroomService
    {
        PetConditionModel CheckPetCondition(int petId);
    }
}
