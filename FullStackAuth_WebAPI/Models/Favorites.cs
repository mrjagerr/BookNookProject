using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class Favorites
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ThumbnailUrl { get; set; }

        [ForeignKey("Owner")]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
