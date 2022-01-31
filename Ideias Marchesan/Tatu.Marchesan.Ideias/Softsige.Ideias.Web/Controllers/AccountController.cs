using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Softsige.Ideias.App.Models;
using Softsige.Ideias.App.Core.Helpers;

namespace Softsige.Ideias.App.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr)
        {
            _userManager = userMgr;
            _signInManager = signinMgr;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            var login = new Login
            {
                ReturnUrl = returnUrl
            };

            return View(login);
        }

        private async Task<IdentityResult> CheckClaims(AppUser appUser)
        {
            var userClaims = await _userManager.GetClaimsAsync(appUser);

            if (userClaims.Count != 0)
            {
                return null;
            }

            var claim = new Claim("Ideias", "Details,Create,Edit,Delete", ClaimValueTypes.String);

            return await _userManager.AddClaimAsync(appUser, claim);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var appUser = await _userManager.FindByNameAsync(login.UserId);

            if (appUser != null)
            {
                await CheckClaims(appUser);
                await _signInManager.SignOutAsync();

                var result = await _signInManager.PasswordSignInAsync(appUser, login.Password, false, false);

                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl ?? "/");
                }
            }

            ModelState.AddModelError(nameof(login.UserId), "Usuário ou Senha é inválido");

            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPassword);
            }

            var user = await _userManager.FindByEmailAsync(resetPassword.Email);

            if (user == null)
            {
                RedirectToAction("ResetPasswordConfirmation");
            }

            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);

            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return View();
            }

            return RedirectToAction("ResetPasswordConfirmation");
        }

        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View("ForgotPasswordConfirmation");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            if (!ModelState.IsValid)
            {
                return View(email);
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

            var emailResponse = new EmailHelper().SendEmailPasswordReset(user.Email, link);

            if (emailResponse)
            {
                return RedirectToAction("ForgotPassword");
            }

            return View(email);
        }

        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
    }
}