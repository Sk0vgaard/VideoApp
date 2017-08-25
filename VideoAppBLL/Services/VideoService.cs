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
        //Interface
        private DALFacade facade;

        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public Video Create(Video vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(vid);
                uow.Complete();
                return newVid;
            }
        }

        public Video Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return newVid;
            }
        }

        public Video Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.Get(Id);
            }
        }

        public List<Video> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.GetAll();
                uow.Complete();
                return newVid;
            }
        }

        public Video Update(Video vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                //Gets the video
                var videoFromDB = uow.VideoRepository.Get(vid.Id);
                //Checks if there is a video.
                if (videoFromDB == null)
                {
                    throw new InvalidOperationException("Video not found...");
                }
                //If there is show info.
                videoFromDB.Title = vid.Title;
                videoFromDB.Genre = vid.Genre;
                videoFromDB.Year = videoFromDB.Year;
                //Save changes.
                uow.Complete();
                return videoFromDB;
            }
        }
    }
}