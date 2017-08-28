using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Entities;

namespace VideoAppDAL
{
    public interface IVideoRepository
    {
        //C
        Video Create(Video vid);

        //R
        List<Video> GetAll();

        Video Get(int Id);

        //U
        //No update for Repository.

        //D
        Video Delete(int Id);
    }
}
