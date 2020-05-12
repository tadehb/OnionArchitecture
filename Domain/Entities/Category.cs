using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category(string name, string description) : base(){
            Name = name;
            Description = description;
            Available = true;
           

        }

        public Category()
        {

        }


        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public bool Available { get; set;}
         
        public  IEnumerable<Photo> Photos { get; set; }
   


    }
}
