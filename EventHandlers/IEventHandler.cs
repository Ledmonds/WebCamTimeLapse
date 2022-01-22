namespace WebCamTimeLapse.EventHandlers;

public interface IEventHandler<T> where T : class
{
    void StartEvent(T newEvent);
    void StopEvent(T oldEvent);
    void StopAllEvents();
}
