using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       
        public bool Available { get; set; }

        public IEnumerable<Photo> Photos { get; set; }


        public CategoryViewModel(Guid id,string name,string description,bool available, IEnumerable<Photo> photos)
        {
            Id = id;
            Name = name;
            Description = description;
            Available = available;
            Photos = photos;
        }
    }
}
