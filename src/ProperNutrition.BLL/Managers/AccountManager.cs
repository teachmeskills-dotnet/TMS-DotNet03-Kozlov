using Microsoft.AspNetCore.Identity;
using ProperNutrition.Common.Interfaces;
using ProperNutrition.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace ProperNutrition.BLL.Managers
{
    /// <inheritdoc cref="IAccountManager"/>
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountManager(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public async Task<IdentityResult> SignUpAsync(string email, string applicationUserName, string password)
        {
            var applicationUser = new ApplicationUser
            {
                Email = email,
                UserName = applicationUserName,

            };
            // добавляем пользователя
            return await _userManager.CreateAsync(applicationUser, password);
        }
    }
}
