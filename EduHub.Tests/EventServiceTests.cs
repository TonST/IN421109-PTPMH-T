using EduHub.Application.Events;
using EduHub.Domain.Entities;
using Moq;

namespace EduHub.Tests;

public class EventServiceTests
{
    [Fact]
    public void CreateEvent_ValidEvent_AddsAndSendsOnce()
    {
        var repository = new Mock<IEventRepository>();
        var notification = new Mock<INotificationService>();
        var service = new EventService(repository.Object, notification.Object);

        service.CreateEvent(Guid.NewGuid(), "Tech Talk", DateTime.UtcNow.AddDays(1), 40, "email");

        repository.Verify(item => item.Add(It.Is<Event>(e => e.Title == "Tech Talk")), Times.Once);
        notification.Verify(item => item.Send("email", "New event: Tech Talk"), Times.Once);
    }
}
