﻿using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BO;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converters
{
    class GenreConverter
    {
        internal Genre Convert(GenreBO genre)
        {
            if (genre == null)
            {
                return null;
            }
            return new Genre()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        internal GenreBO Convert(Genre genre)
        {
            if (genre == null)
            {
                return null;
            }
            return new GenreBO()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
    }
}
