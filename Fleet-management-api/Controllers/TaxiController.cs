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

    public class TaxiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaxiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Taxi>>> GetAsync([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = _context.Taxis.AsQueryable();
            await HttpContext.InsertPaginationHeader(queryable);

            var taxis = await queryable.OrderBy(x => x.Id).Paginate(paginationDTO).ToListAsync();//es recomendable ordenar cuando se pagina
            return taxis;
            // return await _context.Taxis.ToListAsync();
        }

        //// GET api/values/5
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

