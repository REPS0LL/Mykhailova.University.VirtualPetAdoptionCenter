using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VirtualPetAdoptionCenter.Core;
using VirtualPetAdoptionCenter.Core.Services;
using VirtualPetAdoptionCenter.Models.DomainModels;

namespace VirtualPetAdoptionCenter.Web.Pages
{
    public class AllPetsModel : PageModel
    {
        private readonly VirtualPetAdoptionCenterDbContext _db;
        private readonly IEmailService _emailService;
        private readonly IGroomService _groomService;

        public List<PetModel> Pets { get; set; }
        public AllPetsModel(IPetService petService, VirtualPetAdoptionCenterDbContext db, IEmailService emailService, IGroomService groomService)
        {
            Pets = petService.GetAllPets();
            _db = db;
            _emailService = emailService;
            _groomService = groomService;
        }

        public void OnGet()
        {
            var userid = HttpContext.Session.GetInt32(Constants.UserCookieKey);
            var user = _db.Users.FirstOrDefault(x => x.Id == userid);
            var pets = _db.Pets.Where(x => x.UserId == userid).ToList();

            if (user != null)
            {
                foreach (var pet in pets) 
                {
                    var petCondition = _groomService.CheckPetCondition(pet.Id);

                    if (!petCondition.IsWashed)
                    {
                        _emailService.SendEmail(user.Login, Constants.WashedEmail);
                    }
                    if (!petCondition.IsBrushed)
                    {
                        _emailService.SendEmail(user.Login, Constants.BrushEmail);
                    }
                    if (!petCondition.IsNailTrimmed)
                    {
                        _emailService.SendEmail(user.Login, Constants.TrimNailsEmail);
                    }
                    if (!petCondition.IsFeed)
                    {
                        _emailService.SendEmail(user.Login, Constants.FeedEmail);
                    }
                }
            }
        }
    }
}
