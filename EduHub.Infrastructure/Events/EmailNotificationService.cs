using EduHub.Application.Events;
namespace EduHub.Infrastructure.Events;
public sealed class EmailNotificationService : ConsoleNotificationService
{
    protected override string Prefix => "Email";
}
