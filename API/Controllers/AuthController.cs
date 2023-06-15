using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;
using Microsoft.AspNetCore.Identity;
using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;

        public AuthController(UserManager<User> userManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;

        }

        // [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ActionResult<UserDto>> signInUser(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (result)
            {
                return new UserDto
                {
                    FullName = user.FullName,
                    Token = _tokenService.CreateToken(user),
                    UserName = user.Email
                };
            }

            return Unauthorized();
        }
        [HttpPost("signup")]
        public async Task<ActionResult<UserDto>> SignUpUser(RegisterDto request)
        {
            if( await _userManager.Users.AnyAsync(x=>x.UserName ==request.Email )){
                return BadRequest("Username is already taken!");
            }
            var user  = new User{
                FullName = request.FullName,
                Contact = request.Contact,
                Email = request.Email,
                UserName = request.Email,
            };
            var result = await _userManager.CreateAsync(user,request.Password);
            if(result.Succeeded){
                return new UserDto{
                   FullName = user.FullName,
                   Token = _tokenService.CreateToken(user),
                   UserName = user.Email
                };
            }
            return BadRequest(result.Errors);
        }
    }
}