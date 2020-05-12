using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepository
{
    public interface IRepository<in Tkey,T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Tkey id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void DeleteAll(IEnumerable<T> entities);
        bool IsDuplicated(Expression<Func<T, bool>> expression);
        bool Exists(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
