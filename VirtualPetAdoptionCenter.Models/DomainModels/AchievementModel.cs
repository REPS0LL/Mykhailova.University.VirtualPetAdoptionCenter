using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models.Enums;

namespace VirtualPetAdoptionCenter.Models.DomainModels
{
    public class AchievementModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte Feed { get; set; }
        public byte Play { get; set; }
        public byte Adopt { get; set; }
        public byte Environment { get; set; }
    }
}
