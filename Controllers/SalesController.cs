using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("{idUser}")]
        [Authorize]
        [Produces("application/json")]

        public async Task<IActionResult> GetSales(int idUser)
        {
            List<Sales> salesList = await _connectionDb.Sales
        .Where(s => s.IdUser == idUser)
        .ToListAsync();

            if (salesList == null)
            {
                return BadRequest("No tienes historial disponible");
            }

            return Ok(salesList);
        }


        [HttpPost]
        [Authorize]
        [Produces("application/json")]

        public async Task<IActionResult> AddSale([FromBody] Sales sales)
        {
            if (sales == null) {
                return BadRequest("Los campos son obligatorios");
            }


            Sales existingSale = await _connectionDb.Sales
        .FirstOrDefaultAsync(s => s.IdUser == sales.IdUser && s.IdMovie == sales.IdMovie);

            if (existingSale != null)
            {
                return BadRequest($"Ya has comprado la película " + existingSale.title);
            }

            if (existingSale != null)
            {
                return BadRequest("Ya compraste esta pelicula ");
            }

            await _connectionDb.Sales.AddAsync(sales);
            await _connectionDb.SaveChangesAsync();

            return Ok(sales);
        }
        
    }
}
