using Microsoft.AspNetCore.Mvc;
using VirtualPetAdoptionCenter.Core.Services;
using VirtualPetAdoptionCenter.Models.Account;
using VirtualPetAdoptionCenter.Models.Enums;

namespace VirtualPetAdoptionCenter.Web.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        private readonly IAchievementService _achievementTypeService;
        public PetController(IPetService petService, IAchievementService achievementTypeService)
        {
            _petService = petService;
            _achievementTypeService = achievementTypeService;
        }   

        [HttpPost]
        [Route(nameof(Adopt))]
        public IActionResult Adopt([FromForm]int petId)
        {
            var userId = HttpContext.Session.GetInt32(Core.Constants.UserCookieKey);
            _petService.AdoptPet(petId, userId.Value);

            _achievementTypeService.CheckAndAddAdoptAchievementAsync(userId.Value).GetAwaiter().GetResult();

            return RedirectToPage("/AllPets");
        }

    /*    [HttpPost]
        [Route(nameof(FeedPet))]
        public async Task<IActionResult> FeedPet([FromForm] int petId, [FromForm] int userId)
        {
            var isFeed = _petService.FeedPet(petId);

            if (isFeed)
            {
                await _achievementTypeService.CheckAndAddHundredFeedAchievementAsync(userId);
            }
           
            return RedirectToPage("/MyPets");
        }*/

        [HttpGet]
        [Route(nameof(GroomPet))]
        public IActionResult GroomPet(int petId)
        {
            return RedirectToPage("/PetDetails", new { petId = petId });
        }

        [HttpPost]
        [Route(nameof(UpdateGroomingTime))]
        public IActionResult UpdateGroomingTime([FromForm]int petId,[FromForm] GroomType groomType)
        {    
            _petService.UpdateGroomingTime(petId, groomType);
            return RedirectToAction(nameof(GroomPet), new { petId = petId });
        }

        [HttpPost]
        [Route(nameof(SetEnvironment))]
        public async Task<IActionResult> SetEnvironment([FromForm] int petId, [FromForm] PetEnvironmentType environment)
        {
            _petService.SetEnvironment(petId, environment);
            var petEnvironment = _petService.GetEnvironment(petId);

            if (petEnvironment == environment)
            {
                await _achievementTypeService.CheckAndAddEnvironmentAchievementAsync(petId);
            }
            return RedirectToPage("/MyPets");
        }

        [HttpGet]
        [Route(nameof(GetEnvironment))]
        public IActionResult GetEnvironment(int petId)
        {
            var environment = _petService.GetEnvironment(petId);
            return Ok(environment);
        }

        [HttpGet]
        [Route(nameof(PetActivity))]
        public IActionResult PetActivity([FromForm] int petId)
        {
            var pet = _petService.GetPetById(petId);

            if (pet == null)
            {
                return NotFound();
            }
            return RedirectToPage("/PetActivity");

        }
    }
}

