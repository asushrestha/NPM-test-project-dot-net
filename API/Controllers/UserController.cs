using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        public DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;

        }

        [HttpGet("profile")]
        public async Task<ActionResult<List<User>>> GetNurses()
        {

            return await _context.Users.ToListAsync();
        }

    }
}