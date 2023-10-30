using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Migrations;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksDetailController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BooksDetailController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<BooksDetailController>
        [HttpGet]
        public IActionResult Get()
        {
            var reviews = _context.Reviews.ToList();
            return Ok(reviews);
        }

        // GET api/<BooksDetailController>/5
        [HttpGet("{BookId}")]
        public IActionResult GetByBookId(string BookId)
        {

            {
                try
                {
                    var books = _context.Favorites.Select(b => new BookDetailsDto
                    {
                        BookId = b.BookId,
                        ThumbnailUrl = b.ThumbnailUrl,
                        Title = b.Title,
                        Id = b.Id,
                        AverageRating = _context.Reviews.Average(r=>r.Rating),
                        Reviews = _context.Reviews.Select(r => new ReviewWithUserDto
                        {
                            Id = r.Id,
                            Rating = r.Rating,
                            Text = r.Text,
                            User = new UserForDisplayDto
                            {
                                Id = r.User.Id,
                                FirstName = r.User.FirstName,
                                LastName = r.User.LastName,
                                UserName = r.User.UserName,
                            }
                            

                        }).ToList()

                    });




                    // Return the book with list of reviews as a 200 OK response
                    return StatusCode(200, books);
                }
                catch (Exception ex)
                {
                    // If an error occurs, return a 500 internal server error with the error message
                    return StatusCode(500, ex.Message);
                }
            }

        }
    }

    
}
