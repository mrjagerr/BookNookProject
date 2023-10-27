using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class Review
    {
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public string BookId { get; set; }

            [Required]
            public string Text { get; set; }

            [Required]
            public double Rating { get; set; }

            [ForeignKey("Owner")]
            public string UserId { get; set; }

            public User User { get; set; }
        }
    }
}
