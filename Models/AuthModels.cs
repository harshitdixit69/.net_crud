namespace WebApi.Models;

public class RegisterRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class AuthResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public string Role { get; set; }
} 