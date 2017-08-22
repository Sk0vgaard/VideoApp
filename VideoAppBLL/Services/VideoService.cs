using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL;
using VideoAppEntity;

namespace VideoAppBLL.Services
{
    class VideoService : IVideoService
    {
        private IVideoRepository repo;

        public VideoService(IVideoRepository repo)
        {
            this.repo = repo;
        }

        public Video Create(Video vid)
        {
            return this.repo.Create(vid);
        }

        public Video Delete(int Id)
        {
            return repo.Delete(Id);
        }

        public Video Get(int Id)
        {
            return repo.Get(Id);
        }

        public List<Video> GetAll()
        {
            return repo.GetAll();
        }

        public Video Update(Video vid)
        {
            //Gets the video
            var videoFromDB = Get(vid.Id);
            //Checks if there is a video.
            if (videoFromDB == null)
            {
                throw new InvalidOperationException("Video not found...");
            }
            //If there is get info.
            videoFromDB.Title = vid.Title;
            videoFromDB.Genre = vid.Genre;
            videoFromDB.Year = videoFromDB.Year;
            return videoFromDB;
        }
    }
}