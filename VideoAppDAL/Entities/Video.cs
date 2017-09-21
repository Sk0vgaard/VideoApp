using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL.Entities
{
    public class Video
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int PricePrDay { get; set; }

        public int Year { get; set; }

        public List<Rental> Rentals { get; set; }

        public List<VideoGenre> Genres { get; set; }

        public int GenreId { get; set; }
    }
}