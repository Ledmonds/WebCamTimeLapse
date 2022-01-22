using System;
using System.Timers;
using WebCamTimeLapse.Actions;

namespace WebCamTimeLapse.Events;

public class TimerEvent : IEvent<Timer>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    private readonly Timer _timer = new Timer();
    private readonly IAction _action;
    private readonly IDisposableAction _disposeAction;

    public TimerEvent(IAction action, IDisposableAction disposeAction)
    {
        _action = action;
        _disposeAction = disposeAction;
    }

    public void DeregisterEvent()
    {
        _timer.Enabled = false;
        _disposeAction.Invoke();
    }

    public void OnEvent()
    {
        _timer.Elapsed += OnTimedEvent;
    }

    public Timer RegisterEvent()
    {
        _timer.Interval = 30;
        _timer.Elapsed += OnTimedEvent;
        _timer.Enabled = true;

        return _timer;
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        _action.Invoke();
    }
}
