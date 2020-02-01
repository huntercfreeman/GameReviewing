using GameReviewing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Services.Interfaces
{
    public interface IUserService
    {
        public bool Login(string username, string password);
        public User GetUserByUsername(string username);
        public List<User> GetUsers();
        public List<User> GetUsersByFirstName(string firstName);
        public List<User> GetUsersByState(string state);
    }
}
