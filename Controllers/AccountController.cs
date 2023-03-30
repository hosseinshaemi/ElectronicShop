using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MyEshop.Data.Repositories;
using System.Security.Claims;
namespace MyEshop.Models;

public class AccountController : Controller
{
    private IUserRepository _userRepository;
    public AccountController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel register)
    {
        if (!ModelState.IsValid) return View(model: register);
        if (_userRepository.IsExistUserByEmail(register.Email.ToLower()))
        {
            ModelState.AddModelError("Email", "ایمیل وارد شده قبلا ثبت نام کرده است");
            return View(register);
        }
        _userRepository.AddUser(new Users
        {
            Email = register.Email.ToLower(),
            Password = register.Password,
            IsAdmin = false,
            RegisterDate = DateTime.Now,
        });

        return View("SuccessRegister", register);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel login)
    {
        if (!ModelState.IsValid)
            return View(login);
        var user = _userRepository.GetUserForLogin(login.Email.ToLower(),
         login.Password);
        if (user == null)
        {
            ModelState.AddModelError("Email", "اطلاعات صحیح نیست");
            return View(login);
        }
        var claims = new List<Claim>{
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim("IsAdmin", user.IsAdmin.ToString()),
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        var properties = new AuthenticationProperties
        {
            IsPersistent = login.RememberMe,
        };
        HttpContext.SignInAsync(principal, properties);
        return Redirect("/");
    }

    public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/Account/Login");
    }

}

