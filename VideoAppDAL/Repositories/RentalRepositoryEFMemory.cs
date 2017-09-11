﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class RentalRepository : IRentalRepository
    {
        private VideoAppContext _context;
        public RentalRepository(VideoAppContext context)
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