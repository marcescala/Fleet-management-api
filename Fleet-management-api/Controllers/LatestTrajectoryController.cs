using Fleet_management_api.Context;
using Fleet_management_api.DTO;
using Fleet_management_api.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fleet_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LatestTrajectoryController : Controller
    {
        private readonly AppDbContext _context;

        public LatestTrajectoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LastestTrajectoryDTO>>> GetLastestTrajectoriesByTaxiIdAsync(
            int taxiId, [FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = _context.Trajectories.AsQueryable();
            await HttpContext.InsertPaginationHeader(queryable);
            var query = _context.Trajectories
                .Include(t => t.Taxi)
                .GroupBy(t => t.TaxiId)
                .Select(g => g.OrderByDescending(t => t.Date).FirstOrDefault());
            var totalItems = await query.CountAsync();
            var latestTaxis = await query
                   .Paginate(paginationDTO)
                    .ToListAsync();
            var lastLocationResponse = latestTaxis
                .Select(t => new LastestTrajectoryDTO
            {
                Id = t.Taxi.Id,
                Plate = t.Taxi.Plate,
                Latitude = t.Latitude,
                Longitude = t.Longitude,
                Date = t.Date

            }).ToList();
            var response = new
            {
                Items = lastLocationResponse,
                TotalItems = totalItems,
                
            };

            return Ok(response);
        }
        
    }

        

        
    
}

