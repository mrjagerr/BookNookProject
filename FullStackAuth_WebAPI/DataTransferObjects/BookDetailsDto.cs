using Org.BouncyCastle.Bcpg;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class BookDetailsDto
    {
       
        public string BookId { get; set; }
       
        public List<ReviewWithUserDto> Reviews { get; set; }
        public double AverageRating { get; set; }
        public bool isFavorite { get; set; }


    }
}
