using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Application;
using Application.IApplication;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Route("Categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;
        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        [HttpGet(Name = nameof(GetCategories))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetCategories()
        {
            IEnumerable<Category> categories = _categoryApplication.GetCategories();
            if(categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
      
        }

        [HttpGet("{id}",Name = nameof(GetCategory))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetCategory(Guid id)
        {
            var category = _categoryApplication.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
    }
}