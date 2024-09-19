using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_movies.Models;
using server_movies.Services;
using System.Data;

namespace server_movies.Controllers


{
    [ApiController]
    [Route("api/v1/Users")]
    public class UsersController : ControllerBase
    {

        private readonly ConnectionDb _connectionDb;

        public UsersController(ConnectionDb connectionDb)
        {
            _connectionDb = connectionDb;
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] CLogin cLogin)
        {

            if (string.IsNullOrEmpty(cLogin.Email) || string.IsNullOrEmpty(cLogin.Password))
            {
                return BadRequest("Email y contraseña son requeridos.");
            }


            Users? searchUser = await _connectionDb.Users.SingleOrDefaultAsync(x => x.Email == cLogin.Email);
              
              
             if (searchUser != null)
            {
              bool isPasswordValid = Service.VerifyPassword(cLogin.Password, searchUser.Password);
                if (isPasswordValid)
                {

                    string token = Service.GenerateToken(searchUser.Email, "UnaClaveSecretaMuySeguraDe32Bytes!");

                    return Ok(new
                    {
                        idUser = searchUser.IdUser,
                        email = searchUser.Email,
                        token = token

                    });
                }
                else
                {
                    return Unauthorized("Correo electronico o contraseña incorrectos");
                }
            } else
            {
                return BadRequest("Error");
            }

        }


        [HttpGet]
        [Authorize]
        public  async Task<IActionResult> GetUsers()
        {
            var result = await _connectionDb.Users.ToListAsync();

            return Ok(result);
           
        }

        [HttpPost]
       

        public async Task<IActionResult> RegisterUser (
            [FromBody] Users userRequest
            )

        {

            if (userRequest == null)
            {
                return BadRequest("Datos del usuario no pueden ser nulos");
            }

            Users searchUser = await _connectionDb.Users
    .FirstOrDefaultAsync(u => u.Email == userRequest.Email);

            if (searchUser != null)
            {
                return BadRequest("El correo ya está registrado.");
            }

            DateTime now = DateTime.Now;

            Users newUser = new Users { 
             Name = userRequest.Name,
             Last_Name = userRequest.Last_Name,
             Email = userRequest.Email,
             Date_Create = now,
             Active = 1,
             Password = Service.HashPassword(userRequest.Password)
            };


             await _connectionDb.Users.AddAsync(newUser);

             await _connectionDb.SaveChangesAsync();
             return Ok(newUser);

        }
    }
}


