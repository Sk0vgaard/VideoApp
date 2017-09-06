using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BO;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converters
{
    class RentalConverter
    {
        internal Rental Convert(RentalBO rental)
        {
            return new Rental()
            {
                Id = rental.Id,
                OrderDate = rental.OrderDate,
                DeliveryDate = rental.DeliveryDate
            };
        }

        internal RentalBO Convert(Rental rental)
        {
            return new RentalBO()
            {
                Id = rental.Id,
                OrderDate = rental.OrderDate,
                DeliveryDate = rental.DeliveryDate
            };
        }
    }
}
