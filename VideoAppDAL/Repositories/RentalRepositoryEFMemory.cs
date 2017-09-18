using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class RentalRepositoryEFMemory : IRentalRepository
    {
        private VideoAppContext _context;

        public RentalRepositoryEFMemory(VideoAppContext context)
        {
            _context = context;
        }

        public Rental Create(Rental rental)
        {
            _context.Rentals.Add(rental);
            return rental;
        }

        public List<Rental> GetAll()
        {
            return _context.Rentals.ToList();
        }

        public Rental Get(int Id)
        {
            return _context.Rentals.FirstOrDefault(r => r.Id == Id);
        }

        public Rental Delete(int Id)
        {
            var rental = Get(Id);
            _context.Rentals.Remove(rental);
            return rental;
        }
    }
}