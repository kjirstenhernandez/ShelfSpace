

public interface IPasswordService {
    string HashPassword(string password);
    bool VerifyPassword(string inputPassword, string storedHash);
};

public class PasswordService : IPasswordService{


    public string HashPassword (string password) {

        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string inputPassword, string StoredHash){
        return BCrypt.Net.BCrypt.Verify(inputPassword, StoredHash);
    }
    
}
