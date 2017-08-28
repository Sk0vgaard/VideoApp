using System;
using System.Collections.Generic;
using System.Linq;
using VideoAppBLL.BO;
using VideoAppDAL;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Services
{
    internal class VideoService : IVideoService
    {
        //Interface
        private readonly DALFacade facade;

        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public VideoBO Create(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(Convert(vid));
                uow.Complete();
                return Convert(newVid);
            }
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return Convert(newVid);
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return Convert(uow.VideoRepository.Get(Id));
            }
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.GetAll();
                uow.Complete();
                return newVid.Select(Convert).ToList();
            }
        }

        public VideoBO Update(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                //Gets the video
                var videoFromDB = uow.VideoRepository.Get(vid.Id);
                //Checks if there is a video.
                if (videoFromDB == null)
                    throw new InvalidOperationException("Video not found...");
                //If there is show info.
                videoFromDB.Title = vid.Title;
                videoFromDB.Genre = vid.Genre;
                videoFromDB.Year = videoFromDB.Year;
                //Save changes.
                uow.Complete();
                return Convert(videoFromDB);
            }
        }

        private Video Convert(VideoBO vid)
        {
            return new Video()
            {
                Id = vid.Id,
                Title = vid.Title,
                Genre = vid.Genre,
                Year = vid.Year
            };
        }
        private VideoBO Convert(Video vid)
        {
            return new VideoBO()
            {
                Id = vid.Id,
                Title = vid.Title,
                Genre = vid.Genre,
                Year = vid.Year
            };
        }
    }
}