using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeckRoad.DataService.Data;
using TeckRoad.Entities.DbSets;
using TeckRoad.Presentation.Models;

namespace TeckRoad.Presentation.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;

        public UserAuthController(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel) 
        {
            loginModel.LoginInvalid = "true";

            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email, 
                                    loginModel.Password, loginModel.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    loginModel.LoginInvalid = "";
                }
                else {
                    ModelState.AddModelError(string.Empty, "Invalid Login attempt!");
                }
            }

            return PartialView("_UserLoginPartial", loginModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if(returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");   
            }
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationModel registrationModel)
        {
            registrationModel.RegisterationInvalid = "true";

            if(ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = registrationModel.Email,
                    Email = registrationModel.Email,    
                    FirstName = registrationModel.FirstName,
                    LastName = registrationModel.LastName,
                    PhoneNumber = registrationModel.PhoneNumber,
                    Address1 = registrationModel.Address1,
                    Address2 = registrationModel.Address2,
                    PostCode = registrationModel.PostCode
                };

                var result = await _userManager.CreateAsync(user, registrationModel.Password);
                if (result.Succeeded)
                {
                    registrationModel.RegisterationInvalid = "";

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return PartialView("_UserRegistrationPartial", registrationModel);
                }

                ModelState.AddModelError("", "Registeration attempt failed!");
            }

            return PartialView("_UserRegistrationPartial", registrationModel);
        }
    }
}
