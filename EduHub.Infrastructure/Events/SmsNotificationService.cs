using EduHub.Application.Events;
namespace EduHub.Infrastructure.Events;
public sealed class SmsNotificationService : ConsoleNotificationService
{
    protected override string Prefix => "SMS";
}
