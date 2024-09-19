using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_movies.Services;
using System.Net.Http;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

namespace server_movies.Controllers
{
    [ApiController]
    [Route("api/v1/Movies")]
    public class MoviesController : Controller
    {
        
        [HttpGet]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> GetMovies ()
        {
            try
            {
                string response = await Services.Service.MethodGet("https://api.themoviedb.org/3/discover/movie?page=2");
                 return Content(response, "application/json");
            }   catch (HttpRequestException e)

            {
               
                return BadRequest("Ocurrio un error inesperado");
            }      
        }

        [HttpGet("Details/{idMovie}")]
        [Authorize]
        [Produces("application/json")]

        public async Task<IActionResult> GetDetailMovie (int idMovie)
        {
            try
            {
                string response = await Services.Service.MethodGet($"https://api.themoviedb.org/3/movie/{idMovie}");
                return Content($"{response}", "application/json");
            } catch (HttpRequestException e) {
                return BadRequest("Ocurrio un error inesperado");
            }
        }
    }
}
