using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL
{
    //When you are implementing this interface you need to force to implement a disposable function aswell.
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }

        int Complete();
    }
}