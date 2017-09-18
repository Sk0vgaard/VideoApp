using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Repositories;

namespace VideoAppDAL.OUW
{
    class UnitOfWork : IUnitOfWork
    {
        //First repository aviable. 
        public IVideoRepository VideoRepository { get; internal set; }
        public IRentalRepository RentalRepository { get; internal set; }
        public IUserRepository UserRepository { get; }

        //A context that represent the DB. (Connection, table and knows how the db should work.)
        private VideoAppContext context;

        public UnitOfWork()
        {
            context = new VideoAppContext();
            //Creating a repository using the context.
            VideoRepository = new VideoRepositoryEFMemory(context);
            RentalRepository = new RentalRepositoryEFMemory(context);
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