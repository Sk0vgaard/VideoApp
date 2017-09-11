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
            if (rental == null)
            {
                return null;
            }
            return new Rental()
            {
                Id = rental.Id,
                OrderDate = rental.OrderDate,
                DeliveryDate = rental.DeliveryDate,
                //Video is the same video as from RentalBO to convert it to a Video Entity
                Video = new VideoConverter().Convert(rental.Video),
                VideoId = rental.VideoId
            };
        }

        internal RentalBO Convert(Rental rental)
        {
            if (rental == null)
            {
                return null;
            }
            return new RentalBO()
            {
                Id = rental.Id,
                OrderDate = rental.OrderDate,
                DeliveryDate = rental.DeliveryDate,
                Video = new VideoConverter().Convert(rental.Video),
                VideoId = rental.VideoId
            };
        }
    }
}
