using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IApplication
{
    public interface ICategoryApplication
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(Guid id);
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);


    }
}
