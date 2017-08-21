﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL;
using VideoAppEntity;

namespace VideoAppBLL.Services
{
    class VideoService : IVideoService
    {
        public Video Create(Video vid)
        {
            Video newVid;
            FakeDB.Videos.Add(newVid = new Video()
            {
                Id = FakeDB.Id++,
                Title = vid.Title,
                Genre = vid.Genre,
                Year = vid.Year
            });
            return newVid;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            FakeDB.Videos.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
           return FakeDB.Videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(FakeDB.Videos);
        }

        public Video Update(Video vid)
        {
            throw new NotImplementedException();
        }
    }
}