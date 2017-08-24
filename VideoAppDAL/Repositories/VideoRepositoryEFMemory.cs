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
            //Adds the video.
            this.context.Videos.Add(vid);
            //Saves the changes inside the memory.
            this.context.SaveChanges();
            return vid;
        }

        public List<Video> GetAll()
        {
            return this.context.Videos.ToList();
        }

        public Video Get(int Id)
        {
            //Returns the first video on the list or the default one.
            return this.context.Videos.FirstOrDefault(v => v.Id == Id);
        }

        public Video Delete(int Id)
        {
            //Gets the id of the video.
            var vid = Get(Id);
            //Removes the video by the id.
            this.context.Videos.Remove(vid);
            //Saves the changes.
            this.context.SaveChanges();
            return vid;
        }
    }
}
