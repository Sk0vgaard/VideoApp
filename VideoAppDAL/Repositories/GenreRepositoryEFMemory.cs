using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class GenreRepositoryEFMemory : IGenreRepository
    {
        public VideoAppContext _context;

        public GenreRepositoryEFMemory(VideoAppContext context)
        {
            _context = context;
        }


        public Genre Create(Genre genre)
        {
            _context.Genres.Add(genre);
            return genre;
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public IEnumerable<Genre> GetAllById(List<int> ids)
        {
            if (ids == null) return null;
            {
                return _context.Genres.Where(g => ids.Contains(g.Id));
            }
        }

        public Genre Get(int Id)
        {
            return _context.Genres.FirstOrDefault(g => g.Id == Id);
        }

        public Genre Delete(int Id)
        {
            var genre = Get(Id);
            _context.Genres.Remove(genre);
            return genre;
        }
    }
}
