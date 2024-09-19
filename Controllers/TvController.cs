using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server_movies.Controllers
{
    [ApiController]
    [Route("api/v1/TV")]
    public class TvController : Controller
    {

        [HttpGet]
        [Authorize]
        [Produces("application/json")]

        public async Task<IActionResult> GetTv()
        {

            try
            {
                string response = await Services.Service.MethodGet("https://api.themoviedb.org/3/discover/tv");
                return Content($"{response}", "application/json");

            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error inesperado");
            }

        }
        
    }
}
