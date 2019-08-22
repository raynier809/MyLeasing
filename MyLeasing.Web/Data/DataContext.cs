﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {          
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Lesse> Lesses { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }

    }
    
}
