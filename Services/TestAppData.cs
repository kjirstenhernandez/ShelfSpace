namespace ShelfSpace.Services
{
    public class TestAppData
    {
        public List<MediaItem> mediaItems { get; set; } = new List<MediaItem>() {
        new MediaItem { SpecialId = "1", Title = "Home on the Range", Genre = "Family", Year = 2005, Type = MediaType.Movie },
        new MediaItem { SpecialId = "2", Title = "Tom Sawyer", Genre = "Adventure Fiction", Year = 1876, Type = MediaType.Book },
        new MediaItem { SpecialId = "3", Title = "Born in the USA", Genre = "Rock", Year = 1984, Type = MediaType.CD }
    };
    }

}
