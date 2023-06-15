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
    public class AuthController : BaseApiController
    {

        public DataContext _context;
        public AuthController(DataContext context)
        {
            _context = context;

        }

        [HttpPost("signin")]
        public async Task<ActionResult<List<Nurse>>> AuthenticateUser()
        {
            //authentication logic();
            //validate request body
            return await _context.Nurses.ToListAsync();
        }
        [HttpPost("signup")]
        public async Task<ActionResult<Nurse>> GetNurseById(Guid id)
        {
            return await _context.Nurses.FindAsync(id);

        }
    }
}