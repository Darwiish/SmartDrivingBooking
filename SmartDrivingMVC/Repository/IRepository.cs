using System.Collections.Generic;

namespace SmartDrivingMVC.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> ReadAll();

        T Get(int id);

        void Add(T t);

        void Delete(int id);

        void Update(T t);
    }
}
