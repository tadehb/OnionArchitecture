using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.EntityMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Infrastructure.Application.Context
{
    public class ApplicationContext: DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) :base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new CategoryMap());
           // modelBuilder.ApplyConfiguration(new PhotoMap());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            base.OnConfiguring(optionsBuilder);
        }


    }
}
