using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDUHOME.Extensions;
using EDUHOME.Models;
using EDUHOME.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EDUHOME.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        public IActionResult Login()
        {
            return View();
        }

        #region Login

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email ve ya password sehfdi!!!");
                return View();
            }

            if (user.IsDeleted)
            {
                ModelState.AddModelError("", "Hesab bloklanib!!!");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, login.Password, true, true);

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Bir nece deqiqe gozleyin!!!");
                return View(login);
            }

            if (signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email ve ya password sehfdi!!!");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion


        public IActionResult Register()
        {
            return View();
        }

        #region Register

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            AppUser newUser = new AppUser
            {
                Fullname = register.Fullname,
                Email = register.Email,
                UserName = register.Username

            };
            IdentityResult identityResult = await _userManager.CreateAsync(newUser, register.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
           await _userManager.AddToRoleAsync(newUser, Roles.Member.ToString());
            await _signInManager.SignInAsync(newUser, true);
            return RedirectToAction("Index", "Home");
        }

        #endregion


        #region Logout

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion



        #region Create User Role

        //public async Task CreateUserRole()
        //{
        //    if (!(await _roleManager.RoleExistsAsync(Roles.Admin.ToString())))
        //        await _roleManager.CreateAsync(new IdentityRole { Name = Roles.Admin.ToString() });
        //    if (!(await _roleManager.RoleExistsAsync(Roles.Member.ToString())))
        //        await _roleManager.CreateAsync(new IdentityRole { Name = Roles.Member.ToString() });
        //}

        #endregion

    }
}
