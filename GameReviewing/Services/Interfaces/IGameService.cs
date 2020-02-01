using GameReviewing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Services.Interfaces
{
    public interface IGameService
    {
        public List<Game> GetGames();
        public Game GetGameByTitle(string title);
        public List<Game> GetGamesByRating(double rating);
        public Game GetGameById(int id);
    }
}
