using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using VideoAppEntity;

namespace VideoAppDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options =
            new DbContextOptionsBuilder<InMemoryContext>().UseInMemoryDatabase("theDB").Options;

        //Options we want in memory
        public InMemoryContext() : base(options)
        {
        }

        //DBSet
        public DbSet<Video> Videos { get; set; }
    }
}