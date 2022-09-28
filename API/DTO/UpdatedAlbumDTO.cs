namespace API.DTO
{
    public class UpdatedAlbumDTO
    {
        public long AlbumId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
