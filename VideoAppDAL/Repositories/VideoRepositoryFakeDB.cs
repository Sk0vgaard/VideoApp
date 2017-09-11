using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Entities; 

namespace VideoAppDAL.Repositories
{
    class VideoRepositoryFakeDB : IVideoRepository
    {
        #region FakeDB

        private static List<Video> Videos = new List<Video>();
        private static int Id = 1;

        #endregion

        public Video Create(Video vid)
        {
            Video newVid;
            //Adds the new video.
            Videos.Add(newVid = new Video()
            {
                Id = Id++,
                Title = vid.Title,
                PricePrDay = vid.PricePrDay,
                Year = vid.Year
            });
            //Returns the new video.
            return newVid;
        }

        public List<Video> GetAll()
        {
            return new List<Video>(Videos);
        }

        public Video Get(int Id)
        {
            //Returns the first video on the list or the default.
            return Videos.FirstOrDefault(v => v.Id == Id);
        }

        public Video Delete(int Id)
        {
            //Removes the video with the chosen ID.
            var vid = Get(Id);
            Videos.Remove(vid);
            return vid;
        }
    }
}
