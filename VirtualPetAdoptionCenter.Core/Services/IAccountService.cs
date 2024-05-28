using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models.Account;
using VirtualPetAdoptionCenter.Models.DomainModels;
using VirtualPetAdoptionCenter.Models.Enums;
using VirtualPetAdoptionCenter.Models.NewFolder1;

namespace VirtualPetAdoptionCenter.Core.Services
{
	public interface IAccountService
	{
		Task<UserModel> RegisterUserAsync(string login, string password, AuthType authType);
		Task<UserModel> CheckUserExistsAsync(string login, string password, AuthType authType);
    }
}
