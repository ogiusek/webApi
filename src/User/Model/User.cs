namespace WebApi.User.Models;

public class User
{
    public Guid Id { get; private set; }

    public string Email { get; private set; }
    public bool IsEmailVerified { get; private set; } = false;

    // public string PhoneNumber { get; private set; }
    // public bool IsPhoneVerified { get; private set; } = false;

    public string PasswordHash { get; private set; }

    public string Name { get; private set; }
    public string Surname { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    // public List<Role> Roles { get; private set; }

    public User Verify()
    {
        User user = new(this)
        { IsEmailVerified = true };
        return user;
    }

    public User(string email, string passwordHash, string name, string surname) =>
        (Id, Email, PasswordHash, Name, Surname) = (Guid.NewGuid(), email, passwordHash, name, surname);

    public User(User user) =>
        (this.Id, this.Email, this.IsEmailVerified, this.PasswordHash, this.Name, this.Surname, this.CreatedAt) =
        (user.Id, user.Email, user.IsEmailVerified, user.PasswordHash, user.Name, user.Surname, user.CreatedAt);
}
