using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDrivingMVCDAL.DomainModels
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
