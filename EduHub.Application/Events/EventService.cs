using EduHub.Domain.Entities;
namespace EduHub.Application.Events;

public sealed class EventService(IEventRepository repository, INotificationService notificationService)
{
    public IReadOnlyCollection<Event> GetByClubId(Guid clubId) => repository.GetByClubId(clubId);
    public Event? GetById(Guid id) => repository.GetById(id);
    public Event CreateEvent(Guid clubId, string title, DateTime date, int capacity, string channel)
    {
        return CreateEvent(clubId, title, date, capacity, channel, notificationService);
    }

    public Event CreateEvent(Guid clubId, string title, DateTime date, int capacity, string channel, INotificationService sender)
    {
        var @event = Event.Create(clubId, title, date, capacity);
        repository.Add(@event);
        sender.Send(channel, $"New event: {@event.Title}");
        return @event;
    }
    public bool Delete(Guid id) => repository.Delete(id);
}
