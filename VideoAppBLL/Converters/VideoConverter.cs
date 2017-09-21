using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppBLL.BO;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converters
{
    class VideoConverter
    {
        private GenreConverter gConv;

        public VideoConverter()
        {
            gConv = new GenreConverter();
        }


        internal Video Convert(VideoBO vid)
        {
            if (vid == null)
            {
                return null;
            }
            return new Video()
            {
                Id = vid.Id,
                Title = vid.Title,
                PricePrDay = vid.PricePrDay,
                Year = vid.Year,
                //GenreId = vid.GenreId,
                Genres = vid.Genres?.Select(g => new VideoGenre()
                {
                    GenreId = g.Id,
                    VideoId = vid.Id
                }).ToList()
            };
        }

        internal VideoBO Convert(Video vid)
        {
            if (vid == null)
            {
                return null;
            }
            return new VideoBO()
            {
                Id = vid.Id,
                Title = vid.Title,
                PricePrDay = vid.PricePrDay,
                Year = vid.Year,
                //GenreId = vid.GenreId,
                Genres = vid.Genres?.Select(g => new GenreBO()
                {
                    Id = g.VideoId,
                    Name = g.Genre?.Name
                }).ToList()

            };
        }
    }
}