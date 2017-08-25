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
        public IVideoRepository VideoRepository
        {
            //Resturns the new VideoRepositoryFakeDB. Connects with BLLFacade.
            get { return new VideoRepositoryEFMemory(new Context.InMemoryContext()); }
        }

        public IUnitOfWork UnitOfWork
        {
            //Resturns the new VideoRepositoryFakeDB. Connects with BLLFacade.
            get { return new UnitOfWorkMem(); }
        }
    }
}