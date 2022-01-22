namespace WebCamTimeLapse.Events;

public interface IEvent<T> where T : class
{
    T RegisterEvent();
    void DeregisterEvent();
    void OnEvent();
}
