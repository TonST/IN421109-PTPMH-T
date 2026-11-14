using EduHub.Domain.Entities;

namespace EduHub.Tests;

public class RegistrationTests
{
    [Fact]
    public void Create_SetsPendingStatusAndIdentifiers()
    {
        var registration = Registration.Create(Guid.NewGuid(), Guid.NewGuid());
        Assert.Equal(RegistrationStatus.Pending, registration.Status);
        Assert.NotEqual(Guid.Empty, registration.Id);
    }

    [Fact]
    public void Confirm_PendingRegistration_SetsConfirmed()
    {
        var registration = Registration.Create(Guid.NewGuid(), Guid.NewGuid());
        registration.Confirm();
        Assert.Equal(RegistrationStatus.Confirmed, registration.Status);
    }

    [Fact]
    public void Confirm_CancelledRegistration_ThrowsAndKeepsCancelledStatus()
    {
        var registration = Registration.Create(Guid.NewGuid(), Guid.NewGuid());
        registration.Cancel();
        Assert.Throws<InvalidOperationException>(() => registration.Confirm());
        Assert.Equal(RegistrationStatus.Cancelled, registration.Status);
    }

    [Fact]
    public void Create_EmptyMemberId_ThrowsArgumentException() =>
        Assert.Throws<ArgumentException>(() => Registration.Create(Guid.Empty, Guid.NewGuid()));
}
