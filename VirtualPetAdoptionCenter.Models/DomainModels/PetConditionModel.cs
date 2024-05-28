using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetAdoptionCenter.Models.DomainModels
{
    public class PetConditionModel
    {
        public bool IsNailTrimmed { get; set; }
        public bool IsBrushed { get; set; }
        public bool IsWashed { get; set; }
        public bool IsFeed { get; set; }
    }
}
