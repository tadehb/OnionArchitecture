using Domain.Entities;
using Infrastructure.Application.Context;
using Infrastructure.IRepository;
using Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{


    public class BaseRepository<TKey, T> : IRepository<TKey, T> where T : BaseEntity
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void DeleteAll(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            var query = _context.Set<T>().AsQueryable();
            query = query.Where(expression);
            return query.Any();
        }

        public T Get(TKey id)
        {
            return _context.Find<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
             return _context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
        }

        public bool IsDuplicated(Expression<Func<T, bool>> expression)
        {
            var query = _context.Set<T>().AsQueryable();
            return query.Any(expression);
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
