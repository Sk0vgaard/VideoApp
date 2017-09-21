using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Context
{
    class VideoAppContext : DbContext
    {
        static DbContextOptions<VideoAppContext> options =
            new DbContextOptionsBuilder<VideoAppContext>().UseInMemoryDatabase("theDB").Options;

        //Options we want in memory
        public VideoAppContext() : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGenre>()
                .HasKey(vg => new {vg.GenreId, vg.VideoId});

            modelBuilder.Entity<VideoGenre>()
                .HasOne(vg => vg.Genre)
                .WithMany(g => g.Videos)
                .HasForeignKey(vg => vg.GenreId);

            modelBuilder.Entity<VideoGenre>()
                .HasOne(vg => vg.Video)
                .WithMany(v => v.Genres)
                .HasForeignKey(vg => vg.VideoId);

            base.OnModelCreating(modelBuilder);
        }

        //DBSet
        public DbSet<Video> Videos { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}