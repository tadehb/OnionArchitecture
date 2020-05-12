using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EntityMapping
{

    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entityTypeBuilder)
        {
           
            entityTypeBuilder.HasKey(t => t.Id);
            entityTypeBuilder.Property(t => t.Name).IsRequired();
            entityTypeBuilder.Property(t => t.Description);
            entityTypeBuilder.Property(t => t.Available).IsRequired();
            // entityTypeBuilder.HasMany<Photo>(p => p.Photos).WithOne(c => c.Category).HasForeignKey(f=>f.CategoryId);

            entityTypeBuilder.OwnsMany(x => x.Photos, optionBuilder =>
            {
                optionBuilder.HasKey(x => x.Id);

            });

        }
    }
}
