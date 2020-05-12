using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime Deleted_at { get; set; }

        [JsonProperty(Order = -2)]
        public string Href { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            Created_at = DateTime.Now;
           
        }
    }
}
