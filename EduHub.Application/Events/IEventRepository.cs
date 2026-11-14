using EduHub.Domain.Entities;
namespace EduHub.Application.Events;

public interface IEventRepository
{
    IReadOnlyCollection<Event> GetByClubId(Guid clubId);
    Event? GetById(Guid id);
    void Add(Event @event);
    bool Delete(Guid id);
}
