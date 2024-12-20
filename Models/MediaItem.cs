using System.ComponentModel.DataAnnotations;

namespace ShelfSpace;

public class MediaItem {
    
    [Key]
    public string SpecialId { get; set; } = default!;

    public string UserId { get; set; } =default!;

    [Required, MaxLength(100)]
    public string? Title { get; set; } = default!;

    [Required, MaxLength(100)]
    public string Genre { get; set; } = default!;
    
    [Display(Name = "Release Year")]
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

