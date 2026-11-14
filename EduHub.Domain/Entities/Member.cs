namespace EduHub.Domain.Entities;

public sealed class Member
{
    public Guid Id { get; private set; }
    public string Email { get; private set; } = string.Empty;
    private Member() { }

    public static Member Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ArgumentException("Email must not be empty and must contain '@'.", nameof(email));
        return new Member { Id = Guid.NewGuid(), Email = email.Trim() };
    }
}
