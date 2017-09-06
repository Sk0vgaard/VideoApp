using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Entities;

namespace VideoAppDAL
{
    public interface IRentalRepository
    {
        //C
        Rental Create(Rental rental);

        //R
        List<Rental> GetAll();

        Rental Get(int Id);

        //U
        //No update for Repository.

        //D
        Rental Delete(int Id);
    }
}
