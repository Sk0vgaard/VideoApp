using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppEntity;

namespace VideoAppDAL.Repositories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        public InMemoryContext context;

        public VideoRepositoryEFMemory(InMemoryContext context)
        {
            this.context = context;
        }

        public Video Create(Video vid)
        {
            this.context = new InMemoryContext();
            this.context.Videos.Add(vid);
            this.context.SaveChanges();
            return vid;
        }

        public List<Video> GetAll()
        {
            return this.context.Videos.ToList();
        }

        public Video Get(int Id)
        {
            return this.context.Videos.FirstOrDefault(v => v.Id == Id);
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            this.context.Videos.Remove(vid);
            this.context.SaveChanges();
            return vid;
        }
    }
}
