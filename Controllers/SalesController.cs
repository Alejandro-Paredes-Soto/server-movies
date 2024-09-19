using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_movies.Models;

namespace server_movies.Controllers
{
    [ApiController]
    [Route("api/v1/Sales")]
    public class SalesController : Controller
    {

        private readonly ConnectionDb _connectionDb;

        public SalesController(ConnectionDb connectionDb)
        {
            _connectionDb = connectionDb;
        }


        [HttpPost]
        [Authorize]
        [Produces("application/json")]

        public async Task<IActionResult> AddSale([FromBody] Sales sales)
        {
            if (sales == null) {
                return BadRequest("Los campos son obligatorios");
            }

            await _connectionDb.Sales.AddAsync(sales);
            await _connectionDb.SaveChangesAsync();
            return Ok(sales);
        }
        
    }
}
