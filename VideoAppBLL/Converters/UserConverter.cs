using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BO;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converters
{
    class UserConverter
    {
        internal User Convert(UserBO user)
        {
            if (user == null)
            {
                return null;
            }
            return new User()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                RentalId = user.RentalId
            };
        }

        internal UserBO Convert(User user)
        {
            if (user == null)
            {
                return null;
            }
            return new UserBO()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                RentalId = user.RentalId

            };
        }
    }
}