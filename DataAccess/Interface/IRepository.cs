using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interface
{
    public interface IRepository <T> where T : IEntity
    {
        bool Create (T entity);
        T GetOne(Predicate<T> filter = null);
        List<T> GetAll(Predicate<T> filter = null);

        bool Update (T entity);
        bool Delete(T entity);


    }
}
