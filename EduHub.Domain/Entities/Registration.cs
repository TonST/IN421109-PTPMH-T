namespace EduHub.Domain.Entities;

public sealed class Registration
{
    public Guid Id { get; private set; }
    public Guid MemberId { get; private set; }
    public Guid EventId { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public RegistrationStatus Status { get; private set; }
    private Registration() { }

    public static Registration Create(Guid memberId, Guid eventId)
    {
        if (memberId == Guid.Empty) throw new ArgumentException("Member ID cannot be empty.", nameof(memberId));
        if (eventId == Guid.Empty) throw new ArgumentException("Event ID cannot be empty.", nameof(eventId));
        return new Registration
        {
            Id = Guid.NewGuid(), MemberId = memberId, EventId = eventId,
            RegisteredAt = DateTime.UtcNow, Status = RegistrationStatus.Pending
        };
    }

    public void Confirm()
    {
        if (Status != RegistrationStatus.Pending)
            throw new InvalidOperationException("Only pending registrations can be confirmed.");
        Status = RegistrationStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status is not (RegistrationStatus.Pending or RegistrationStatus.Confirmed))
            throw new InvalidOperationException("Only pending or confirmed registrations can be cancelled.");
        Status = RegistrationStatus.Cancelled;
    }
}
