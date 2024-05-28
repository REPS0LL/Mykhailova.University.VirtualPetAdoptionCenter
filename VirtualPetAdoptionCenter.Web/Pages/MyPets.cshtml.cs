using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VirtualPetAdoptionCenter.Core;
using VirtualPetAdoptionCenter.Core.Services;
using VirtualPetAdoptionCenter.Models.DomainModels;

namespace VirtualPetAdoptionCenter.Web.Pages
{
    public class MyPetsModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly IAchievementService _achievementService;
        private readonly IGroomService _groomService;

        public List<PetModel> Pets { get; set; }
        public List<PetConditionModel> PetConditions { get; set; }
        public AchievementModel Achievement { get; set; }
        public PetConditionModel PetCondition { get; set; }


        public MyPetsModel(IPetService petService, IAchievementService achievementService, IGroomService groomService)
        {        
            _petService = petService;
            _achievementService = achievementService;
            _groomService = groomService;
        }


        public void OnGet()
        {

            var userId = HttpContext.Session.GetInt32(Constants.UserCookieKey);

            if (userId.HasValue)
            {
                Pets = _petService.GetPetsByUserId(userId.Value);
                PetConditions = new List<PetConditionModel>();

                foreach (var pet in Pets) 
                {
                    var condition = _groomService.CheckPetCondition(pet.Id);
                    PetConditions.Add(condition);
                }

                Achievement =  _achievementService.GetAchivement(userId.Value);
            }
        }
    }
}
    
