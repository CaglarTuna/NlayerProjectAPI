using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NLayerProject.Web.ApiServices;
using NLayerProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NLayerProject.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly PersonApiService _personApiService;
        private readonly IMapper _mapper;

        public AccountController(IMapper mapper, PersonApiService personApiService)
        {
            _personApiService = personApiService;
            _mapper = mapper;
        }
        public  IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(PersonDto personDto)
        {
            try
            {
                ClaimsIdentity claimsIdentity = null;
                bool isAuthUser = false;
                if (personDto.mail=="Caglar1"&&personDto.password=="12345")
                {
                    claimsIdentity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name,personDto.mail),
                        new Claim(ClaimTypes.Role,"user")
                    },CookieAuthenticationDefaults.AuthenticationScheme
                    );
                    isAuthUser = true;
                }
                if (personDto.mail == "Admin" && personDto.password == "12345")
                {
                    claimsIdentity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name,personDto.mail),
                        new Claim(ClaimTypes.Role,"admin")
                    }, CookieAuthenticationDefaults.AuthenticationScheme
                    );
                    isAuthUser = true;
                }
                if (isAuthUser)
                {
                    var principal = new ClaimsPrincipal(claimsIdentity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                }
                var check = await _personApiService.Login(personDto);
                if (check == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
