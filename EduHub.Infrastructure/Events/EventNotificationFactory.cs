using EduHub.Application.Events;
namespace EduHub.Infrastructure.Events;

public sealed class EventNotificationFactory(EmailNotificationService email, SmsNotificationService sms) : IEventNotificationFactory
{
    public INotificationService Create(string channel) => channel.Trim().ToLowerInvariant() switch
    {
        "email" => email,
        "sms" => sms,
        _ => throw new ArgumentException("Channel must be 'email' or 'sms'.", nameof(channel))
    };
}
