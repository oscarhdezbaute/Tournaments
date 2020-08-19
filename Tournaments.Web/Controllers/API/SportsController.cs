using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tournaments.Web.Data;
using Tournaments.Web.Data.Entities;
using Tournaments.Web.Helpers;

namespace Tournaments.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]

    public class SportsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IConverterHelper _converterHelper;

        public SportsController(DataContext dataContext, IConverterHelper converterHelper)
        {
            _dataContext = dataContext;
            _converterHelper = converterHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSports()
        {
            List<SportEntity> sports = await _dataContext.Sports.Include(s => s.Tournaments)
                                                                .ThenInclude(t => t.Groups)
                                                                .ThenInclude(g => g.GroupDetails)
                                                                .ThenInclude(gd => gd.Team)
                                                                .Include(s => s.Tournaments)
                                                                .ThenInclude(t => t.Groups)
                                                                .ThenInclude(g => g.Matches)
                                                                .ThenInclude(m => m.Local)
                                                                .Include(s => s.Tournaments)
                                                                .ThenInclude(t => t.Groups)
                                                                .ThenInclude(g => g.Matches)
                                                                .ThenInclude(m => m.Visitor)
                                                                .ToListAsync();

            return Ok(_converterHelper.ToSportResponse(sports));

        }
    }
}