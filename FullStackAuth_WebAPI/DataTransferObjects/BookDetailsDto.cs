namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class BookDetailsDto
    {
        public int Id { get; set; }
        public string BookId { get; set; }
        public string Title { get; set; }
        public string ThumbnailUrl { get; set; }

        public ICollection<ReviewWithUserDto> Reviews { get; set; }
        public double AverageRating { get; set; }


    }
}
