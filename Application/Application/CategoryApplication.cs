using Application.IApplication;
using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application
{
    public class CategoryApplication : ICategoryApplication
    {

        private readonly CategoryRepository _categoryRepository;

        public CategoryApplication(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void DeleteCategory(Category category)
        {
            try
            {
                _categoryRepository.Delete(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetCategory(Guid id)
        {
            return _categoryRepository.Get(id);
        }

        public void InsertCategory(Category category)
        {
            _categoryRepository.Insert(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
