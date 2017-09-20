using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppBLL.BO;
using VideoAppBLL.Converters;
using VideoAppDAL;

namespace VideoAppBLL.Services
{
    class GenreService : IGenreService
    {
        GenreConverter _conv;
        DALFacade _facade;

        public GenreService(DALFacade facade)
        {
            _facade = facade;
            _conv = new GenreConverter();
        }

        public GenreBO Create(GenreBO genre)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newGenre = uow.GenreRepository.Create(_conv.Convert(genre));
                uow.Complete();
                return _conv.Convert(newGenre);
            }
        }

        public List<GenreBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newGenre = uow.GenreRepository.GetAll();
                return newGenre.Select(_conv.Convert).ToList();
            }
        }

        public GenreBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return _conv.Convert(uow.GenreRepository.Get(Id));
            }
        }

        public GenreBO Update(GenreBO genre)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreFromDb = uow.GenreRepository.Get(genre.Id);
                if (genreFromDb == null)
                {
                    throw new InvalidOperationException("Genre not found");
                }
                var genreUpdate = _conv.Convert(genre);

                genreFromDb.Name = genreUpdate.Name;

                uow.Complete();

                return _conv.Convert(genreFromDb);
            }
        }

        public GenreBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newGenre = uow.GenreRepository.Delete(Id);
                uow.Complete();
                return _conv.Convert(newGenre);
            }
        }
    }
}
