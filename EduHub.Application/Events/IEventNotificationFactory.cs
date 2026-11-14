namespace EduHub.Application.Events;
public interface IEventNotificationFactory { INotificationService Create(string channel); }
