namespace ShelfSpace;

public class User {


    public string Id { get; set; }

    [Required, MaxLength(100)]
    public string? Name {get; set; }

    [Required, MaxLength(100)]
    public string? LastName {get; set; }

    [Required, MaxLength (100), EmailAddress]
    public string?  Email { get; set; }

    [Required, MaxLength(15)]
    public string?  Phone { get; set; }

    [Required, MaxLength (100)]
    public string? Address { get; set; }

    public string? BirthDate { get; set; }

    [Required]
    public string PasswordHash { get; set; }

}