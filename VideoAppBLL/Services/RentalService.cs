using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppBLL.BO;
using VideoAppBLL.Converters;
using VideoAppDAL;

namespace VideoAppBLL.Services
{
    class RentalService : IRentalService
    {
        RentalConverter conv = new RentalConverter();
        private DALFacade _facade;

        public RentalService(DALFacade facade)
        {
            _facade = facade;
        }

        public RentalBO Create(RentalBO rental)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Create(conv.Convert(rental));
                uow.Complete();
                return conv.Convert(rentalEntity);
            }
        }

        public List<RentalBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newRental = uow.RentalRepository.GetAll();
                return newRental.Select(conv.Convert).ToList();
            }
        }

        public RentalBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Get(Id);    
                rentalEntity.Video = uow.VideoRepository.Get(rentalEntity.VideoId);
                return conv.Convert(rentalEntity);
            }
        }

        public RentalBO Update(RentalBO rental)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Get(rental.Id);
                if (rentalEntity == null)
                {
                    throw new InvalidOperationException("Rental not found.");
                }
                rentalEntity.OrderDate = rental.OrderDate;
                rentalEntity.DeliveryDate = rental.DeliveryDate;
                rentalEntity.VideoId = rentalEntity.VideoId;

                uow.Complete();
                //BLL choice
                rentalEntity.Video = uow.VideoRepository.Get(rentalEntity.VideoId);
                return conv.Convert(rentalEntity);
            }
        }

        public RentalBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(rentalEntity);
            }
        }
    }
}