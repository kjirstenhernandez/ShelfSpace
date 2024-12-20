namespace ShelfSpace.Models;

public class UserCred {

    [Required]
    public string? Email {get;set;}
    
    [Required, MaxLength(15)]
    public string? Password {get;set;}
}

