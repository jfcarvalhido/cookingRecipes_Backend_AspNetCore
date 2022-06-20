using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.DAL.Context;
using RecipesApp.DAL.Repositories;
using RecipesApp.Domain.Entities;
using RecipesApp.Domain.Models.Users;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesApp.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]    
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;           
        }
        

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = new User 
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email
            };

            if (!ModelState.IsValid) return BadRequest();

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok("User Registado");                
            }           
            return BadRequest("User não registado");
        }       

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Email);
                    //user role list here
                    var roles = await _userManager.GetRolesAsync(user);
                    //get default role here
                    string role = roles.FirstOrDefault();
                    if (role.Equals("Admin"))
                    {
                        return RedirectToAction("AdminActionName", "AdminControllerName");
                    }
                    else if (role.Equals("User"))
                    {
                        return RedirectToAction("UserActionName", "UserControllerName");
                    }
                    else
                    {
                        //do something here. put in your logic 
                    }
                }
            }
            ModelState.AddModelError("", "Invalid ID or Password");
            return Ok();
            //return View(model);
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
