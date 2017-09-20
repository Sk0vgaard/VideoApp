﻿using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Entities;

namespace VideoAppDAL
{
    public interface IGenreRepository
    {
        //C
        Genre Create(Genre genre);

        //R
        List<Genre> GetAll();

        Genre Get(int Id);

        //U
        //No update for Repository.

        //D
        Genre Delete(int Id);
    }
}
