using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Repositories;

namespace VideoAppDAL.OUW
{
    class UnitOfWorkMem : IUnitOfWork
    {
        //First repository aviable. 
        public IVideoRepository VideoRepository { get; internal set; }
        //A context that represent the DB. (Connection, table and knows how the db should work.)
        private InMemoryContext context;

        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            //Creating a repository using the context.
            VideoRepository = new VideoRepositoryEFMemory(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Complete()
        {
            //The number of objects written to the underlying database.
            return context.SaveChanges();
        }
    }
}