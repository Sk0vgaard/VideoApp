using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.Services;
using VideoAppDAL;

namespace VideoAppBLL
{
    public class BLLFacade
    {
        public IVideoService VideoService
        {
            //Returns new VideoService from DALFacade.
            get { return new VideoService(new DALFacade()); }
        }

        public IRentalService RentalService
        {
            //Returns new VideoService from DALFacade.
            get { return new RentalService(new DALFacade()); }
        }

        public IUserService UserService
        {
            //Returns the new UserService from DALFacade.
            get { return new UserService(new DALFacade());}
        }
    }
}