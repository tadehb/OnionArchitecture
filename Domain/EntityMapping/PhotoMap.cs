using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EntityMapping
{
    public class PhotoMap : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(t => t.Id);
            entityTypeBuilder.Property(t => t.Name).IsRequired();
            entityTypeBuilder.Property(t => t.Available).IsRequired();
            entityTypeBuilder.OwnsOne(x => x.Category, optionBuilder =>
            {
                optionBuilder.HasKey(x => x.Id);
               

            });



        }
    }
}
