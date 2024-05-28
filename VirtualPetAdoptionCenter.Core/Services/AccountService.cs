using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models.Account;
using VirtualPetAdoptionCenter.Models.NewFolder1;

namespace VirtualPetAdoptionCenter.Core.Services
{
	public class AccountService : IAccountService
    {
		private readonly VirtualPetAdoptionCenterDbContext _dbContext;
        private readonly IEncryption _encryptionService;
        private readonly IEmailService _emailService;

        public AccountService(VirtualPetAdoptionCenterDbContext dbContext,IEncryption encryptionService, IEmailService emailService)
		{
			_dbContext = dbContext;
            _emailService = emailService;
            this._encryptionService = encryptionService;
		}

		public async Task<UserModel> RegisterUserAsync(string login, string password, AuthType authType)
		{
			var user = await CheckUserExistsAsync(login, password, authType);
			
            if ( user != null)
			{
				return user;
			}

			var newUser = new UserModel
			{
				Login = login,
				Password = _encryptionService.Encrypt(password),
                AuthType = authType.ToString()
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
            _emailService.SendEmail(login, Constants.RegistrationEmailTemplate);
            user = await CheckUserExistsAsync(login, password, authType);

            return user;
        }

		public async Task<UserModel> CheckUserExistsAsync(string login, string password, AuthType authType)
		{
			password = _encryptionService.Encrypt(password);
			var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password && u.AuthType == authType.ToString());

            return user;
		}
	}
}

