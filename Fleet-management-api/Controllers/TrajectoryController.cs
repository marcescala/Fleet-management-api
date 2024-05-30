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
        public async Task<ActionResult<IEnumerable<Trajectory>>> GetTrajectoriesByTaxiIdAndDateAsync(
            int taxiId, [FromQuery] DateTime date, [FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = _context.Trajectories.AsQueryable();
            await HttpContext.InsertPaginationHeader(queryable);

            var searchDate = date.ToUniversalTime().Date;
            var trajectories = await queryable.Paginate(paginationDTO)
                .Where(t => t.TaxiId == taxiId && t.Date.Date == searchDate)
             
                .ToListAsync();

            if (trajectories == null)
            {
                return NotFound();
            }

            return trajectories;
        }


        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

