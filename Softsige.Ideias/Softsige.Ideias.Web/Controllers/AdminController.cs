using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Softsige.Ideias.App.Core.Helpers;
using Softsige.Ideias.App.Models;
using Softsige.Ideias.App.ViewModels;
using Softsige.Ideias.Domain.Interfaces.Service;

namespace Softsige.Ideias.App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserValidator<AppUser> _userValidator;
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(
            IAdminService adminService,
            IMapper mapper,
            IUserValidator<AppUser> userValidator,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _adminService = adminService;
            _mapper = mapper;
            _userValidator = userValidator;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        #region Usuario

        public IActionResult Index()
        {
            var result = _mapper.Map<IEnumerable<UsuariosFiltroViewModel>>(_userManager.Users);

            return View(result);
        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var appUser = new AppUser { UserName = user.Name, Email = user.Email };
            var result = await _userManager.CreateAsync(appUser, user.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var appUser = new AppUser { UserName = user.Name, Email = user.Email };
            var result = await _userManager.CreateAsync(appUser, user.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(user);
        }

        [AllowAnonymous]
        public IActionResult RegisterUser()
        {
            return View("RegisterUser");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var rolesUser = new List<RoleViewModel>();

            foreach (var item in await _userManager.GetRolesAsync(user))
            {
                var role = await _roleManager.FindByNameAsync(item);
                rolesUser.Add(new RoleViewModel { Id = role.Id, Name = role.Name, UserId = user.Id });
            }

            ViewData["UserId"] = user.Id;
            ViewData["RolesUser"] = rolesUser;
            ViewData["Claims"] = _mapper.Map<IEnumerable<ClaimViewModel>>(await _userManager.GetClaimsAsync(user));
            ViewData["AllRoles"] = CommonHelper.SelectList(await GetAllRoleIdentity(), "Value", "Value");
            ViewData["AddClaimRoles"] = CommonHelper.SelectList(await GetAllModules(), "Value", "Value");
            ViewData["AddClaimRolesClaim"] =
                CommonHelper.SelectList(await GetClaimValueByRoleName("Ideias", id), "ClaimValue", "ClaimValue");

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppUser user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var claimsPrincipal = await _userManager.GetClaimsAsync(user);
            ViewData["Claims"] = _mapper.Map<IEnumerable<ClaimViewModel>>(claimsPrincipal);

            var appUser = await _userManager.FindByIdAsync(user.Id);

            if (appUser != null)
            {
                IdentityResult validUser;

                if (!string.IsNullOrEmpty(user.Email))
                {
                    appUser.Email = user.Email;
                    validUser = await _userValidator.ValidateAsync(_userManager, appUser);

                    if (!validUser.Succeeded)
                    {
                        Errors(validUser);
                    }
                }
                else
                {
                    return View(appUser);
                }

                if (!validUser.Succeeded)
                {
                    return View(appUser);
                }

                var result = await _userManager.UpdateAsync(appUser);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                return View(appUser);
            }

            ModelState.AddModelError("", "Usuário não encontrado");

            return View(user);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                Errors(result);
            }

            ModelState.AddModelError("", "Usuario não encontrado.");

            return View("Index");
        }

        private void Errors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        public async Task<IActionResult> GetUsuarioList(string userName, string email)
        {
            var result = await GetUsuariosList();

            if (!string.IsNullOrEmpty(userName))
            {
                result = result
                    .Where(x => x.UserName.Contains(userName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(email))
            {
                result = result
                    .Where(x => x.Email.Contains(email, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return PartialView("_ListaUsuarios", result);
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
        private async Task<List<UsuariosFiltroViewModel>> GetUsuariosList()
        {
            return await _userManager.Users
                .Select(x => new UsuariosFiltroViewModel { Id = x.Id, Email = x.Email, UserName = x.UserName })
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion Usuario

        #region Claim

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarClaim(ClaimViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            var claim = new Claim(model.Type, model.Value, ClaimValueTypes.String);
            var result = await _userManager.AddClaimAsync(user, claim);

            if (!result.Succeeded)
            {
                return Json(new { success = false });
            }

            var url = Url.Action("GetClaimList", "Admin", new { model.UserId });

            return Json(new { success = true, url });
        }

        public async Task<IActionResult> ExcluirClaim(string userId, string claimValues)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return Json(new { success = false });
            }

            var claimValuesArray = claimValues.Split(";");
            string claimType = claimValuesArray[0], claimValue = claimValuesArray[1];
            var claimsPrincipal = await _userManager.GetClaimsAsync(user);
            var claim = claimsPrincipal.FirstOrDefault(x => x.Type == claimType && x.Value == claimValue);
            var result = await _userManager.RemoveClaimAsync(user, claim);

            if (!result.Succeeded)
            {
                return Json(new { success = false });
            }

            var url = Url.Action("GetClaimList", "Admin", new { userId });

            return Json(new { success = true, url });
        }

        public async Task<IActionResult> GetClaimList(string userId)
        {
            ViewBag.UserId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            var claimsPrincipal = await _userManager.GetClaimsAsync(user);
            var result = _mapper.Map<IEnumerable<ClaimViewModel>>(claimsPrincipal);

            return PartialView("_ListaClaims", result);
        }

        public async Task<IEnumerable<RoleClaimViewModel>> GetClaimValueByRoleName(string roleName, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var claims = await _adminService.GetClaimsValueByRoleName(roleName);

            foreach (var item in await _userManager.GetClaimsAsync(user))
            {
                claims = claims.Where(x => x.RoleName != item.Type && x.ClaimValue != item.Value);
            }

            return _mapper.Map<IEnumerable<RoleClaimViewModel>>(claims);
        }

        #endregion Claim

        #region Role

        public async Task<IActionResult> ExcluirRoleUser(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return Json(new { success = false });
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);

            if (!result.Succeeded)
            {
                return Json(new { success = false });
            }

            var url = Url.Action("GetRoleUserList", "Admin", new { userId });

            return Json(new { success = true, url });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarRoleUsuario(RoleViewModel model)
        {
            var role = await _roleManager.FindByNameAsync(model.Name);
            var user = await _userManager.FindByIdAsync(model.UserId);
            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (!result.Succeeded)
            {
                return Json(new { success = false });
            }

            var url = Url.Action("GetRoleUserList", "Admin", new { userId = model.UserId });

            return Json(new { success = true, url });
        }

        public async Task<IActionResult> GetRoleUserList(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = new List<RoleViewModel>();

            foreach (var item in await _userManager.GetRolesAsync(user))
            {
                var role = await _roleManager.FindByNameAsync(item);
                result.Add(new RoleViewModel { Id = role.Id, Name = role.Name, UserId = user.Id });
            }

            return PartialView("_ListaRole", result);
        }

        public async Task<IEnumerable<string>> GetAllRoleList()
        {
            return await _adminService.GetAllRole();
        }

        public async Task<IEnumerable<ClaimViewModel>> GetAllModules()
        {
            var result = new List<ClaimViewModel>();

            foreach (var item in await GetAllRoleList())
            {
                result.Add(new ClaimViewModel { Type = item, Value = item });
            }

            return result.Distinct();
        }

        public async Task<IEnumerable<ClaimViewModel>> GetAllRoleIdentity()
        {
            var result = new List<ClaimViewModel>();

            foreach (var item in await _roleManager.Roles.ToListAsync())
            {
                result.Add(new ClaimViewModel { Type = item.Name, Value = item.Name });
            }

            return result.Distinct();
        }

        #endregion Role
    }
}