using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdt.Data.Respository
{
    public interface IRepository<T, in TKey> : IDisposable where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(TKey id);
        IQueryable<T> GetAll();
        bool Save();
    }
}
