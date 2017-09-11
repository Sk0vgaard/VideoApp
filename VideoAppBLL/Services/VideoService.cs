using System;
using System.Collections.Generic;
using System.Linq;
using VideoAppBLL.BO;
using VideoAppBLL.Converters;
using VideoAppDAL;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Services
{
    internal class VideoService : IVideoService
    {
        private VideoConverter conv = new VideoConverter();

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
                var newVid = uow.VideoRepository.Create(conv.Convert(vid));
                uow.Complete();
                return conv.Convert(newVid);
            }
        }

        public void CreateAll(List<VideoBO> videoes)
        {
            using (var uow = facade.UnitOfWork)
            {
                foreach (var video in videoes)
                {
                    uow.VideoRepository.Create(conv.Convert(video));

                }
                uow.Complete();
            }
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newVid);
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)

            {
                var videoFromDB = uow.VideoRepository.Get(Id);
                VideoBO videoToReturn = null;
                //Checks if there is a video with the ID.
                if (videoFromDB != null)
                {
                    videoToReturn = conv.Convert(videoFromDB);
                }
                else
                {
                    Console.WriteLine("Can't find the video by the ID");
                }

                return videoToReturn;
            }
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.GetAll();
                uow.Complete();
                return newVid.Select(conv.Convert).ToList();
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
                {
                    throw new InvalidOperationException("Video not found.");
                    //Console.WriteLine("Video doesn't exist");
                    //return null;
                }
                //If there is show info.
                videoFromDB.Title = vid.Title;
                videoFromDB.PricePrDay = vid.PricePrDay;
                videoFromDB.Year = vid.Year;
                //Save changes.
                uow.Complete();
                return conv.Convert(videoFromDB);
            }
        }

        
    }
}