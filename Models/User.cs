namespace ShelfSpace.Models;

public class User {

    [Required]
    public string UserId { get; set; } = Guid.NewGuid().ToString();

    [Required, MaxLength(100)]
    public string Name {get; set; } = default!;

    [Required, MaxLength (100), EmailAddress]
    public string Email { get; set; } = default!;

    [Required, MaxLength(15)]
    public string  Phone { get; set; } = default!;

    public List<MediaItem> MediaShelf {get; set; } = new List<MediaItem>();

}