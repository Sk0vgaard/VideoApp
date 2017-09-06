using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.OUW;
using VideoAppDAL.Repositories;

namespace VideoAppDAL
{
    public class DALFacade
    {

        public IUnitOfWork UnitOfWork
        {
            //Resturns the new VideoRepositoryFakeDB. Connects with BLLFacade.
            get { return new UnitOfWork(); }
        }
    }
}