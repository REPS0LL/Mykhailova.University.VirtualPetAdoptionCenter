using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
/*using VirtualPetAdoptionCenter.Core.Models;
*/
using VirtualPetAdoptionCenter.Core.Services;
using System.Collections.Generic;
using VirtualPetAdoptionCenter.Models.DomainModels;

namespace VirtualPetAdoptionCenter.Web.Pages
{
    public class PetDetailsModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly IGroomService _groomService;

        public PetModel Pet { get; set; }
        public PetConditionModel PetCondition { get; set; }

        public PetDetailsModel(IPetService petService, IGroomService groomService)
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
