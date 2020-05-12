using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Photo : BaseEntity
    {
        public Photo(string name, Guid id):base()
        {
            Name = name;
            Available = true;
        }
        public Photo()
        {

        }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Available { get; set; }
        public Guid CategoryId { get; set; }
        [JsonIgnore]
        public  Category Category { get; set;}
      

    }
}
