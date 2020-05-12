using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class PhotoViewModel
    {
      
        public Guid Id { get; set; }
        public string Name { get; set; }
      
        public bool Available { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public PhotoViewModel(Guid id,string name, bool available, Guid categoryId, Category category)
        {
            Id = id;
            Name = name;
            Available = available;
            CategoryId = categoryId;
            Category = category;  
        }
    }
}
