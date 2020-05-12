using Domain.Entities;
using Infrastructure.Application.Context;
using Infrastructure.IRepositories;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Guid, Category>, ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Category GetCategory(Guid id) {

            return _context.Categories.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public void Insert(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();

        }

       
    }
}
