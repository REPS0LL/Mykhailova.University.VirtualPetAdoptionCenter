using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetAdoptionCenter.Models.DomainModels
{
    public class GroomingModel
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public DateTime TrimNailsTime { get; set; }
        public DateTime WashTime { get; set; }
        public DateTime BrushTime { get; set; }
        public DateTime FeedTime { get; set; }
    }
}
