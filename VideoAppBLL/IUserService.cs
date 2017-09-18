using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BO;

namespace VideoAppBLL
{
    public interface IUserService
    {
        //C
        UserBO Create(UserBO rental);

        //R
        List<UserBO> GetAll();

        UserBO Get(int Id);

        //U
        UserBO Update(UserBO user);

        //D
        UserBO Delete(int Id);
    }
}
