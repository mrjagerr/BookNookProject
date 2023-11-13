using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Migrations;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        public IActionResult GetByBookId(string bookId) 
        {
            
            {
                try

                {
                    var bookStrId = bookId.ToString();
                    
                    var bookDetails = new BookDetailsDto
                    {


                        BookId = bookStrId,
                        AverageRating = _context.Reviews.Where(r => r.BookId == bookStrId).Average(r => r.Rating),
                        Reviews = _context.Reviews.Where(r=> r.BookId==bookStrId).Select(r => new ReviewWithUserDto
                        {
                            Id = r.Id,
                            Rating = r.Rating,
                            Text = r.Text,
                            BookId = r.BookId,
                            User =  new UserForDisplayDto
                            {
                                Id = r.User.Id,
                                FirstName = r.User.FirstName,
                                LastName = r.User.LastName,
                                UserName = r.User.UserName,
                            }



                        }).ToList()

                    };


                    return Ok(bookDetails);
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
