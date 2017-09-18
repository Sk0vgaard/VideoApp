using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppBLL.BO;
using VideoAppBLL.Converters;
using VideoAppDAL;

namespace VideoAppBLL.Services
{
    class UserService : IUserService
    {
        UserConverter conv = new UserConverter();
        private DALFacade _facade;

        public UserService(DALFacade facade)
        {
            _facade = facade;
        }

        public UserBO Create(UserBO rental)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var userEntity = uow.UserRepository.Create(conv.Convert(rental));
                uow.Complete();
                return conv.Convert(userEntity);
            }
        }

        public List<UserBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newUser = uow.UserRepository.GetAll();
                return newUser.Select(conv.Convert).ToList();
            }
        }

        public UserBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newUser = uow.UserRepository.Get(Id);
                return conv.Convert(newUser);
            }
        }

        public UserBO Update(UserBO user)
        {
            using (var uow = _facade.UnitOfWork)
            {
                //Gets the user
                var userFromDB = uow.UserRepository.Get(user.Id);
                //Checks if there is a user.
                if (userFromDB == null)
                {
                    throw new InvalidOperationException("User not found.");
                }
                //If there is show info.
                userFromDB.Username = user.Username;
                userFromDB.Password = user.Password;
                //Save changes.
                uow.Complete();
                return conv.Convert(userFromDB);
            }
        }

        public UserBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newUser = uow.UserRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newUser);
            }
        }
    }
}
