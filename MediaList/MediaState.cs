using Microsoft.EntityFrameworkCore;
using ShelfSpace.Data;

namespace ShelfSpace
{
    public class MediaState
    {
        private readonly HttpClient _httpClient;
        private readonly ShelfSpaceContext _context;

        public MediaItem MediaItem { get; set; }

        public MediaState(HttpClient httpClient, ShelfSpaceContext context)
        {
            _httpClient = httpClient;
            _context = context;

            MediaItem = new MediaItem();
        }

        // Reset for new instance
        public void ResetMedia()
        {
            MediaItem = new MediaItem();
        }
    }
}