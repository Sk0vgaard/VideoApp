using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BO;

namespace VideoAppBLL
{
    public interface IGenreService
    {
        //C
        GenreBO Create(GenreBO genre);

        //R
        List<GenreBO> GetAll();

        GenreBO Get(int Id);

        //U
        GenreBO Update(GenreBO genre);

        //D
        GenreBO Delete(int Id);
    }
}
