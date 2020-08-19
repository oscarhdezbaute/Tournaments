using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tournaments.Web.Data;
using Tournaments.Web.Data.Entities;

namespace Tournaments.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]

    public class TournamentsController : ControllerBase
    {
        private readonly DataContext _context;

        public TournamentsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTournaments()
        {
            List<TournamentEntity> tournaments = await _context.Tournaments.Include(t=>t.Groups).ToListAsync();
            return Ok(tournaments);
        }
    }
}