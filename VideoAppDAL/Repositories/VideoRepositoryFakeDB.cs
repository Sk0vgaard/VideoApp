using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppEntity;

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
            Videos.Add(newVid = new Video()
            {
                Id = Id++,
                Title = vid.Title,
                Genre = vid.Genre,
                Year = vid.Year
            });
            return newVid;
        }

        public List<Video> GetAll()
        {
            return new List<Video>(Videos);
        }

        public Video Get(int Id)
        {
            return Videos.FirstOrDefault(x => x.Id == Id);
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            Videos.Remove(vid);
            return vid;
        }
    }
}
