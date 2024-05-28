using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models.Enums;

namespace VirtualPetAdoptionCenter.Models.DomainModels
{
    public class PetModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? EnvironmentType { get; set; }
    }
}
