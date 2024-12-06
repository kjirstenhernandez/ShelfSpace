using System.ComponentModel.DataAnnotations;

namespace ShelfSpace.Models;

public class MediaItem {
    
    public int SpecialId { get; set; }

    [Required, MaxLength(100)]
    public string Title { get; set; } = default!;

    [Required, MaxLength(100)]
    public string Genre { get; set; } = default!;
    
    [Required, Range(1099, 2025, ErrorMessage = "Year must be between 1099 and 2025")]
    public int Year { get; set; }
    
    [Required]
    public MediaType Type { get; set; }
}

public enum MediaType
{
    Movie,
    Book,
    CD,
    TVShow
}