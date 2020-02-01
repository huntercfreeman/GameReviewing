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
                ImagePath = "content/images/WorldOfWarcraft.jfif"
            },
            new Game
            {
                Title = "Pokemon",
                Reviews = new List<Review> { new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" } },
                Id = 2,
                ImagePath = "content/images/pokemon.jfif"
            },
            new Game
            {
                Title = "Grand Theft Auto",
                Reviews = new List<Review> 
                { 
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/gta.jfif"
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
    }
}
