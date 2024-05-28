using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VirtualPetAdoptionCenter.Core.Services;
using VirtualPetAdoptionCenter.Models.DomainModels;

namespace VirtualPetAdoptionCenter.Web.Pages
{
    public class PetActivityModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly IGroomService _groomService;

        public List<PetModel> Pets { get; set; }
        public PetModel Pet { get; set; }
        public PetConditionModel PetCondition { get; set; }


        public PetActivityModel(IPetService petService, IGroomService groomService)
        {
            _petService = petService;
            _groomService = groomService;
        }

        public IActionResult OnGet(int petId)
        {
            Pet = _petService.GetPetById(petId);
            PetCondition = _groomService.CheckPetCondition(petId);
         
            if (Pet == null)
            {
                return NotFound();
            }

            return Page();

        }
    }
}
