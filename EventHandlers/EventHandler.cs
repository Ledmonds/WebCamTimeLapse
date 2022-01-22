using System;
using System.Collections.Generic;
using System.Linq;
using WebCamTimeLapse.Events;

namespace WebCamTimeLapse.EventHandlers;

public class EventHandler : IEventHandler<TimerEvent>
{
    private IReadOnlyCollection<TimerEvent> _events = Array.Empty<TimerEvent>();

    public void StartEvent(TimerEvent newEvent)
    {
        newEvent.RegisterEvent();

        _events = _events
            .Append(newEvent)
            .ToArray();
    }

    public void StopEvent(Guid id)
    {
        var item = _events.Single(x => x.Id == id);
        StopEvent(item);
    }

    public void StopEvent(TimerEvent oldEvent)
    {
        _events = _events
            .Where(@event => @event.Id != oldEvent.Id)
            .ToArray();
    }

    public void StopAllEvents()
    {
        foreach(var item in _events)
        {
            item.DeregisterEvent();
        }

        _events = Array.Empty<TimerEvent>();
    }
}
