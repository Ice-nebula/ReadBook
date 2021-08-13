using AutoMapper;
using Book.Interfaces;
using Book.Models;
using Book.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _token;
        public UserController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IMapper mapper, ITokenService token)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _token = token;
        }
        public IActionResult Register()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            
            if (ModelState.IsValid == false) return View(registerVm);
            try
            {
                var map = _mapper.Map<UserModel>(registerVm);
                var createUser = await _userManager.CreateAsync(map, registerVm.Password);
                if (createUser.Succeeded == false)
                {
                    foreach (var error in createUser.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
            } //end try
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            } //end catch
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm loginVm,string ReturnUrl = null)
        {
            try
            {
                if (ModelState.IsValid == false) return View(loginVm);
                var queryUser = await _userManager.FindByNameAsync(loginVm.UserName);
                if (queryUser == null)
                {
                    ModelState.AddModelError("", "ขอโทษค่ะ ไม่มีชื่อนี้ในระบบโปรดสมัคสมาชิกก่อนนะคะ");
                    return View(loginVm);
                }
                var loginResault = await _signInManager.PasswordSignInAsync(queryUser, loginVm.Password, false, false);
                if (loginResault.Succeeded == true)
                {
                    var genToken = _token.GenerateToken(queryUser);
                    HttpContext.Response.Cookies.Append("AccessToken", genToken);
                }
                else if (loginResault.Succeeded == false)
                {
                    ModelState.AddModelError("", "ขอโทษค่ะ ไม่สามาถเข้าสู่ระบบได้ กรุณาลองใหม่ อีกครั้งนะคะ");
                    return View();
                } //end if
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            } //end catch
            return RedirectToAction("Index", "Home");
        } //end method.Login

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        } //end method.Logout
    } //end class
} //end name space
