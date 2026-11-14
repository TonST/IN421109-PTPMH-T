using EduHub.Application.Events;

namespace EduHub.Infrastructure.Events;

public abstract class ConsoleNotificationService : INotificationService
{
    protected abstract string Prefix { get; }

    public void Send(string channel, string message) => Console.WriteLine($"[{Prefix}] {message}");
}
