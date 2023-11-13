using System.Security.Claims;
using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Migrations;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public FavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<FavoritesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FavoritesController>/5
        [HttpGet("myFavorites"), Authorize]
        public IActionResult GetUsersFavorites()
        {
            try
            {
                // Retrieve the authenticated user's ID from the JWT token
                string userId = User.FindFirstValue("id");
         


                // Retrieve all favorites that belong to the authenticated user, including the owner object
                var favorites = _context.Favorites.Where(c => c.UserId.Equals(userId));

                

                // Return the list of cars as a 200 OK response
                return StatusCode(200, favorites);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<FavoritesController>
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Favorites data)
        {
            try
            {
                // Retrieve the authenticated user's ID from the JWT token
                string userId = User.FindFirstValue("id");

                // If the user ID is null or empty, the user is not authenticated, so return a 401 unauthorized response
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }

                // Set the favorite owner ID  the authenticated user's ID we found earlier
                data.UserId = userId;

                // Add the car to the database and save changes
                _context.Favorites.Add(data);
                if (!ModelState.IsValid)
                {
                    // If the favorite model state is invalid, return a 400 bad request response with the model state errors
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();

                // Return the newly created favorite as a 201 created response
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

       

        // DELETE api/<FavoritesController>/5
        [HttpDelete("{BookId}"), Authorize]
        public IActionResult Delete(string BookId)
        {

            try
            {
                string userId = User.FindFirstValue("id");

                var favorite = _context.Favorites.Find(BookId);
                if (favorite == null)
                {
                    return NotFound();
                }
                _context.Favorites.Remove(favorite);
                _context.SaveChanges();
                return NoContent();

            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }

        }
    }
}
