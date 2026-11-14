using EduHub.Application.Events;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.API.Controllers;

[ApiController]
public sealed class EventsController(EventService eventService, IEventNotificationFactory notificationFactory) : ControllerBase
{
    [HttpGet("api/clubs/{clubId:guid}/events")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetByClub(Guid clubId) => Ok(eventService.GetByClubId(clubId));

    [HttpGet("api/events/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id) => eventService.GetById(id) is { } item ? Ok(item) : NotFound();

    [HttpPost("api/clubs/{clubId:guid}/events")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(Guid clubId, [FromBody] CreateEventRequest request)
    {
        try
        {
            var sender = notificationFactory.Create(request.Channel);
            var created = eventService.CreateEvent(clubId, request.Title, request.Date, request.Capacity, request.Channel, sender);
            return Created($"/api/events/{created.Id}", created);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Invalid event request",
                Detail = ex.Message,
                Status = StatusCodes.Status400BadRequest
            });
        }
    }

    [HttpDelete("api/events/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id) => eventService.Delete(id) ? NoContent() : NotFound();
}

public sealed record CreateEventRequest(string Title, DateTime Date, int Capacity, string Channel);
