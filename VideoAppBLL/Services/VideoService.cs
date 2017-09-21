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
        private GenreConverter gConv = new GenreConverter();

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
                var videoFromDB = conv.Convert(uow.VideoRepository.Get(Id));
                //VideoBO videoToReturn = null;
                //Checks if there is a video with the ID.
                if (videoFromDB.GenreIds != null)
                {
                    //videoFromDB.Genres = videoFromDB.GenreIds
                    //    .Select(id => gConv.Convert(uow.GenreRepository.Get(id)))
                    //    .ToList();
                    videoFromDB.Genres = uow.GenreRepository.GetAllById(videoFromDB.GenreIds)
                        .Select(g => gConv.Convert(g))
                        .ToList();
                }
                else
                {
                    Console.WriteLine("Can't find the video by the ID");
                }
                return videoFromDB;
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
                }

                var videoUpdate = conv.Convert(vid);
                //If there is show info.
                videoFromDB.Title = videoUpdate.Title;
                videoFromDB.PricePrDay = videoUpdate.PricePrDay;
                videoFromDB.Year = videoUpdate.Year;

                //1. Remove all, except the "old" ids we wanna keep (Avoid attached issues)
                videoFromDB.Genres.RemoveAll(
                    vg => !videoUpdate.Genres.Exists(
                        g => g.GenreId == vg.GenreId && 
                        g.VideoId == vg.VideoId));

                //2. Remove all ids already in database from videoUpdate.
                videoUpdate.Genres.RemoveAll(
                    vg => videoFromDB.Genres.Exists(
                        g => g.GenreId == vg.GenreId &&
                        g.VideoId == vg.VideoId));

                //3. Add All new videoGenres not yet seen in the DB.
                videoFromDB.Genres.AddRange(
                    videoUpdate.Genres);

                //Save changes.
                uow.Complete();
                return conv.Convert(videoFromDB);
            }
        }
    }
}