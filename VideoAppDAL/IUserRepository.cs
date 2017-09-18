using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Entities;

namespace VideoAppDAL
{
    public interface IUserRepository
    {
        //C
        User Create(User user);

        //R
        List<User> GetAll();

        User Get(int Id);

        //U
        //No update for Repository.

        //D
        User Delete(int Id);
    }
}
