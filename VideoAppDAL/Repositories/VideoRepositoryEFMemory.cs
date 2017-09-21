using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        public VideoAppContext _context;

        public VideoRepositoryEFMemory(VideoAppContext context)
        {
            _context = context;
        }

        public Video Create(Video vid)
        {
            //Adds the video.
            _context.Videos.Add(vid);
            return vid;
        }

        public List<Video> GetAll()
        {
            return _context.Videos.Include(v => v.Genres).ThenInclude(vg => vg.Genre).ToList();
        }

        public Video Get(int Id)
        {
            //Returns the first video on the list or the default one.
            return _context.Videos.FirstOrDefault(v => v.Id == Id);
        }

        public Video Delete(int Id)
        {
            //Gets the id of the video.
            var vid = Get(Id);
            //Removes the video by the id.
            _context.Videos.Remove(vid);
            return vid;
        }
    }
}
