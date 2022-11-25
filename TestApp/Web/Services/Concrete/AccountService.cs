using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Services.Abstract;
using Web.ViewModels.Account;

namespace Web.Services.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly ModelStateDictionary _modelState;

        public AccountService( IActionContextAccessor actionContextAccessor, 
                                UserManager<User> userManager,
                                SignInManager<User> signInManager)
        {
            _actionContextAccessor = actionContextAccessor;
            _modelState = actionContextAccessor.ActionContext.ModelState;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(AccountLoginVM model)
        {
            if (!_modelState.IsValid) return false;


            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                _modelState.AddModelError(string.Empty, "Username or Password is incorrect");
                return false;
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                _modelState.AddModelError(string.Empty, "Username or Password is incorrect");
                return false;
            }

            return true;
        }

        public async Task<bool> RegisterAsync(AccountRegisterVM model)
        {
            if (!_modelState.IsValid) return false;

            var user = new User
            {
                Fullname = model.Fullname,
                Email = model.Email,
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                   _modelState.AddModelError(string.Empty, error.Description);
                }

                return false ;
            }
            return true;
        }
    }
}
