using GameReviewing.Models;
using GameReviewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Services.Implementations
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>()
        {
            new User
            {
                Username = "jarrett_goldberg@gmail.com",
                Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                FirstName = "Jarrett",
                LastName = "Goldberg",
                Address = new Address { State = "NJ" },
                FavoritedGames = new List<int> { 1 }
            },
            new User
            {
                Username = "john_smith@gmail.com",
                Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                FirstName = "John",
                LastName = "Smith",
                Address = new Address { State = "FL" },
                FavoritedGames = new List<int> { 2 }
            },
            new User
            {
                Username = "tim_gane@gmail.com",
                Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                FirstName = "Tim",
                LastName = "Gane",
                Address = new Address { State = "TX" },
                FavoritedGames = new List<int> { 3 }
            }
        };

        public bool Login(string username, string password)
        {
            return _users.Where(x => (x.Username.CompareTo(username) == 0) /*&& (x.Password.CompareTo(password) == 0)*/).ToList().Count > 0;
        }

        public User GetUserByUsername(string username)
        {
            return _users.Where(x => x.Username.CompareTo(username) == 0).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public List<User> GetUsersByFirstName(string firstName)
        {
            return _users.Where(x => x.FirstName.CompareTo(firstName) == 0).ToList();
        }

        public List<User> GetUsersByState(string state)
        {
            return _users.Where(x => x.Address.State.CompareTo(state) == 0).ToList();
        }
    }
}
