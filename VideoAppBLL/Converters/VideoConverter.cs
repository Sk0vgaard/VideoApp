using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BO;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converters
{
    class VideoConverter
    {
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
                Genre = vid.Genre,
                Year = vid.Year
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
                Genre = vid.Genre,
                Year = vid.Year
            };
        }
    }
}