using System.Collections.Concurrent;
using EduHub.Application.Events;
using EduHub.Domain.Entities;
namespace EduHub.Infrastructure.Events;

public sealed class InMemoryEventRepository : IEventRepository
{
    private readonly ConcurrentDictionary<Guid, Event> _events = new();
    public IReadOnlyCollection<Event> GetByClubId(Guid clubId) => _events.Values.Where(item => item.ClubId == clubId).ToArray();
    public Event? GetById(Guid id) => _events.GetValueOrDefault(id);
    public void Add(Event @event) => _events[@event.Id] = @event;
    public bool Delete(Guid id) => _events.TryRemove(id, out _);
}
