using System.Collections.Generic;

namespace WebCamTimeLapse.Repositories;

public interface IRepository<T>
{
    void Add(T entity);
    void Remove(T entity);
    IReadOnlyCollection<T> GetAll();
}