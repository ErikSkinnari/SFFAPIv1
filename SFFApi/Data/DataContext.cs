﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SFFApi.Domain;

namespace SFFApi.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Trivia> Trivias { get; set; }
        public DbSet<MovieLoanInstance> MovieLoans { get; set; }
        public DbSet<MovieLibraryObject> MovieLibrary { get; set; }

    }
}
