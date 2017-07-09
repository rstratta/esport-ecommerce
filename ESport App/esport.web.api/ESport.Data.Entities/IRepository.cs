using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Data.Entities
{
    public interface IRepository<T>
    {
        void AddEntity(T entity);

        void UpdateEntity(T entity);

        void RemoveEntity(T entity);

        List<T> GetAllEntities();

    }
}
