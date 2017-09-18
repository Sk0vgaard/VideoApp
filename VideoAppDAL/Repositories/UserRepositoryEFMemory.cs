using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class UserRepositoryEFMemory : IUserRepository
    {
        private VideoAppContext _context;

        public UserRepositoryEFMemory(VideoAppContext context)
        {
            _context = context;
        } 
        public User Create(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Get(int Id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == Id);
        }

        public User Delete(int Id)
        {
            var user = Get(Id);
            _context.Users.Remove(user);
            return user;
        }
    }
}
