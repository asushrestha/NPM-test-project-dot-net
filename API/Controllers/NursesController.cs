using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    
    public class NursesController: BaseApiController
    {
        public DataContext _context;
        public NursesController(DataContext context)
        {
            _context = context;
            
        }

        [HttpGet("nurse")]
        public async Task<ActionResult<List<Domain.Nurse>>> GetNurses(){
            
            return await _context.Nurses.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Nurse>> GetNurseById(Guid id){
                        return await _context.Nurses.FindAsync(id);

        }
    }
}