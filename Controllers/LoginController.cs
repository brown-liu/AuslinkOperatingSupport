using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AuslinkOperatingSupport.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>

        /// post 登录请求

        /// </summary>

        /// <returns></returns>

        [HttpPost]

        public async Task<IActionResult> Login(string userName, string password)

        {

            if (userName.Equals("admin") && password.Equals("admin"))

            {

                var claims = new List<Claim>()
                {new Claim(ClaimTypes.Name,userName),new Claim("password",password)
                };

                var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Customer"));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties

                {

                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),

                    IsPersistent = false,

                    AllowRefresh = false

                });

                return Redirect("/Home/Index");

            }

            return Json(new { result = false, msg = "用户名密码错误!" });

        }



        /// <summary>

        /// 退出登录

        /// </summary>

        /// <returns></returns>

        public async Task<IActionResult> Logout()

        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Login");


        }
    }
}