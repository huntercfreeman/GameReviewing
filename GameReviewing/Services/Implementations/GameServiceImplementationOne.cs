using GameReviewing.Models;
using GameReviewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Services.Implementations
{

    //public class GameServiceHunterImplementation : IGameService
    //{

    //    private ILogger _logger;

    //    public GameServiceHunterImplementation(ILogger logger)
    //    {
    //        _logger = logger;
    //    }

    //    private List<Game> _games = new List<Game>()
    //    {
    //        new Game
    //        {
    //            Name = "Skyrim",
    //            Ratings = new List<double> { 4.5 }
    //        },
    //        new Game
    //        {
    //            Name = "Temtem",
    //            Ratings = new List<double> { 3.0, 5.0 }
    //        },
    //        new Game
    //        {
    //            Name = "Oblivion",
    //            Ratings = new List<double> { 1.0, 5.0 }
    //        }
    //    };

    //    public Game GetGameByName(string name)
    //    {
    //        _logger.Log("GetGameByName was called");
    //        return _games.Where(x => x.Name.CompareTo(name) == 0).FirstOrDefault();
    //    }

    //    public List<Game> GetGames()
    //    {
    //        _logger.Log("GetGames was called");
    //        return _games;
    //    }

    //    public List<Game> GetGamesByRating(double rating)
    //    {
    //        _logger.Log("GetGamesByRating");
    //        return _games.Where(x => x.Rating == rating).ToList();
    //    }
    //}
}
