using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_movies.Models;

namespace server_movies.Controllers
{
    [ApiController]
    [Route("api/v1/ShoppingCar")]
    public class ShoppingCarController : Controller
    {

        private readonly ConnectionDb _connectionDb;

        public ShoppingCarController(ConnectionDb connectionDb)
        {
            _connectionDb = connectionDb;
        }

        [HttpPost("addMovieCar")]
        [Authorize]

        public async Task<IActionResult> AddMovieCar([FromBody] ShoppingCar shoppingCar)
        {
            if (shoppingCar.IdMovie != 0 && shoppingCar.IdUser != 0)
            {
                await _connectionDb.ShoppingCar.AddAsync(shoppingCar);

                await _connectionDb.SaveChangesAsync();

                return Ok("Pelicula agregada al carrito");
            }

            return BadRequest("Campos requeridos");

        }
    }
}
