
namespace ShelfSpace;

public class UserState
{
    private readonly HttpClient _httpClient;

    public User? CurrentUser { get; private set; }
    public string? AuthToken { get; private set; }

    public event Action OnUserStateChanged;

    public bool IsAuthenticated => !string.IsNullOrEmpty(AuthToken);

    // API request information 
    public UserState(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void SetUser(User user, string token)
    {
        CurrentUser = user;
        AuthToken = token;
        OnUserStateChanged?.Invoke();
        
    }

    // Upon logout, clears the user
    public void ClearUser()
    {
        CurrentUser = null;
        AuthToken = null;
         OnUserStateChanged?.Invoke(); 
    }

    // Method to fetch user data across pages
    public async Task<User?> GetCurrentUserAsync()
    {

        if (CurrentUser != null)
        {
            return CurrentUser;
        }

        try
        {
            CurrentUser = await _httpClient.GetFromJsonAsync<User>("/api/user/current");

            // If Authentication is needed, this call will validate whether or not a token is in place. (Taken from stackoverflow)
            if (AuthToken != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthToken);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching current user: {ex.Message}");
            CurrentUser = null;
        }

        return CurrentUser;
    }
}

