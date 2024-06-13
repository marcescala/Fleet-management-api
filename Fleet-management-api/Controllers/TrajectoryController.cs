using System;
using Fleet_management_api.Context;
using Fleet_management_api.DTO;
using Fleet_management_api.Models;
using Fleet_management_api.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fleet_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TrajectoryController : Controller
    {
        private readonly AppDbContext _context;

        public TrajectoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{taxiId}")]
        public async Task<ActionResult<IEnumerable<TrajectoryDTO>>> GetTrajectoriesByTaxiIdAndDateAsync(
            int taxiId, [FromQuery] DateTime date, [FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = _context.Trajectories.AsQueryable();
            // Consulta para obtener todas las trayectorias
            await HttpContext.InsertPaginationHeader(queryable);
            var searchDate = date.ToUniversalTime().Date;
            var query = _context.Trajectories
                .Where(t => t.TaxiId == taxiId && t.Date.Date == searchDate)
                .Select(t => new TrajectoryDTO
                {
                    Date = t.Date,
                    Longitude = t.Longitude,
                    Latitude = t.Latitude
                });
            // Consulta que filtra por TaxiId y fecha, selecciona las coincidencias 
            var paginatedResult = await query
                .Paginate(paginationDTO)
                .ToListAsync();


         

            if (paginatedResult == null)
            {
                return NotFound();
            }

            return paginatedResult;
        }

     
    }
}

