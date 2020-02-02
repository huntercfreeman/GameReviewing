using GameReviewing.Models;
using GameReviewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Services.Implementations
{
    public class GameServiceImplementationTwo : IGameService
    {
        private ILogger _logger;

        public GameServiceImplementationTwo(ILogger logger)
        {
            _logger = logger;
        }

        private List<Game> _games = new List<Game>()
        {
            new Game
            {
                Title = "World of Warcraft",
                Reviews = new List<Review> { new Review { Rating = 5, Description = "Love it", UserUsername = "jarrett_goldberg@gmail.com" } },
                Id = 1,
                ImagePath = "content/images/World of Warcraft-285x380.jpg"
            },
            new Game
            {
                Title = "Smite",
                Reviews = new List<Review> { new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" } },
                Id = 2,
                ImagePath = "content/images/Smite-285x380.jpg"
            },
            new Game
            {
                Title = "Elder Scrolls V Skyrim",
                Reviews = new List<Review> 
                { 
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/The Elder Scrolls V_ Skyrim-285x380.jpg"
            },
            new Game
            {
                Title = "Dark Souls",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Dark Souls-285x380.jpg"
            },
            new Game
            {
                Title = "Dark Souls II",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Dark Souls II_ Scholar of the First Sin-285x380.jpg"
            },
            new Game
            {
                Title = "Hearthstone",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Hearthstone-285x380.jpg"
            },
            new Game
            {
                Title = "Portal 2",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Portal 2-285x380.jpg"
            },
            new Game
            {
                Title = "League of Legends",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/League of Legends-285x380.jpg"
            },
            new Game
            {
                Title = "Dota 2",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Dota 2-285x380.jpg"
            },
            new Game
            {
                Title = "The Elder Scrolls IV",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/The Elder Scrolls IV_ Oblivion-285x380.jpg"
            }
        };

        private int _nextId = 4;
        public int NextId 
        { 
            get => _nextId++;
        }

        public Game GetGameByTitle(string title)
        {
            _logger.Log("GetGameByName was called");
            return _games.Where(x => x.Title.CompareTo(title) == 0).FirstOrDefault();
        }

        public List<Game> GetGames()
        {
            _logger.Log("GetGames was called");
            return _games;
        }

        public List<Game> GetGamesByRating(double rating)
        {
            _logger.Log("GetGamesByRating");
            return _games.Where(x => x.Rating == rating).ToList();
        }

        public Game GetGameById(int id)
        {
            _logger.Log("GetGameById");
            return _games.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        ///     returns bool to indicate if
        ///     adding the game was successful.
        /// </returns>
        public bool AddGame(Game game)
        {
            _games.Add(game);

            return true;
        }
    }
}
