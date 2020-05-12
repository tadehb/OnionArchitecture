using Domain.Entities;
using Infrastructure.IRepository;
using Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.IRepositories
{
    public interface ICategoryRepository : IRepository<Guid, Category>
    {
    }
}
