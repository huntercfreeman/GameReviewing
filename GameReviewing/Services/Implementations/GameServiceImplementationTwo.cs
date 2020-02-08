using GameReviewing.Models;
using GameReviewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            },
            new Game
            {
                Title = "Apex Legends",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Apex Legends-285x380.jpg"
            },
            new Game
            {
                Title = "Call of Duty Modern Warfare",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Call of Duty_ Modern Warfare-285x380.jpg"
            },
            new Game
            {
                Title = "Counter-Strike Global Offensive",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Counter-Strike_ Global Offensive-285x380.jpg"
            },
            new Game
            {
                Title = "Dead by Daylight",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Dead by Daylight-285x380.jpg"
            },
            new Game
            {
                Title = "Destiny 2",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Destiny 2-285x380.jpg"
            },
            new Game
            {
                Title = "Detroit Become Human",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Detroit_ Become Human-285x380.jpg"
            },
            new Game
            {
                Title = "Escape From Tarkov",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Escape From Tarkov-285x380.jpg"
            },
            new Game
            {
                Title = "FIFA",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/FIFA 20-285x380.jpg"
            },
            new Game
            {
                Title = "Fortnite",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Fortnite-285x380.jpg"
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
                ImagePath = "content/images/Grand Theft Auto V-285x380.jpg"
            },
            new Game
            {
                Title = "Journey to the Savage Planet",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Journey to the Savage Planet-285x380.jpg"
            },
            new Game
            {
                Title = "Jump Off The Bridge",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Jump Off The Bridge-285x380.jpg"
            },
            new Game
            {
                Title = "Legends of Runeterra",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Legends of Runeterra-285x380.jpg"
            },
            new Game
            {
                Title = "Magic The Gathering",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Magic_ The Gathering-285x380.jpg"
            },
            new Game
            {
                Title = "Minecraft",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Minecraft-285x380.jpg"
            },
            new Game
            {
                Title = "Overwatch",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Overwatch-285x380.jpg"
            },
            new Game
            {
                Title = "Path of Exile",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Path of Exile-285x380.jpg"
            },
            new Game
            {
                Title = "PLAYERUNKNOWN'S BATTLEGROUNDS",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/PLAYERUNKNOWN'S BATTLEGROUNDS-285x380.jpg"
            },
            new Game
            {
                Title = "Poker",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Poker-285x380.jpg"
            },
            new Game
            {
                Title = "ScourgeBringer",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/ScourgeBringer-285x380.jpg"
            },
            new Game
            {
                Title = "Super Mario",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Super Mario 64-285x380.jpg"
            },
            new Game
            {
                Title = "Teamfight Tactics",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Teamfight Tactics-285x380.jpg"
            },
            new Game
            {
                Title = "They Are Billions",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/They Are Billions-285x380.jpg"
            },
            new Game
            {
                Title = "Tom Clancy's Rainbow Six Siege",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Tom Clancy's Rainbow Six_ Siege-285x380.jpg"
            },
            new Game
            {
                Title = "Warcraft III",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/Warcraft III-285x380.jpg"
            },
            new Game
            {
                Title = "World of Tanks",
                Reviews = new List<Review>
                {
                    new Review { Rating = 5, Description = "Love it", UserUsername = "tim_gane@gmail.com" },
                    new Review { Rating = 1, Description = "Hate it", UserUsername = "john_smith@gmail.com" }
                },
                Id = 3,
                ImagePath = "content/images/World of Tanks-285x380.jpg"
            }
        };

        private Dictionary<string, List<Game>> _autocompleteSearchDictionary = new Dictionary<string, List<Game>>();

        private bool autocompleteSearchDictionaryNeedsUpdated = true;

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

        public List<Game> GetGamesByTitle(string title)
        {   
            if(autocompleteSearchDictionaryNeedsUpdated)
            {
                CreateAutocompleteSearchDictionary();
                autocompleteSearchDictionaryNeedsUpdated = false;
            }

            List<Game> result;

            bool success = _autocompleteSearchDictionary.TryGetValue(title, out result);
            
            if(success)
                return result;

            return new List<Game>();
        }

        public void CreateAutocompleteSearchDictionary()
        {
            _autocompleteSearchDictionary = new Dictionary<string, List<Game>>();

            foreach(Game game in _games)
            {
                string[] titleSplit = game.Title.Split(' ');

                int index = 0;

                foreach(string word in titleSplit)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach(char character in word)
                    {
                        stringBuilder.Append(character);

                        List<Game> currentList;

                        bool success = _autocompleteSearchDictionary.TryGetValue(stringBuilder.ToString(), out currentList);

                        
                        if (success)
                        {
                            currentList.Add(game);
                        }
                        else
                        {
                            currentList = new List<Game>();
                            currentList.Add(game);
                            _autocompleteSearchDictionary.Add(stringBuilder.ToString(), currentList);
                        }
                    }
                    foreach(string otherWord in titleSplit.Skip(index + 1))
                    {
                        stringBuilder.Append(' ');

                        List<Game> currentListTemp;

                        bool successTemp = _autocompleteSearchDictionary.TryGetValue(stringBuilder.ToString(), out currentListTemp);

                        if (successTemp)
                        {
                            currentListTemp.Add(game);
                        }
                        else
                        {
                            currentListTemp = new List<Game>();
                            currentListTemp.Add(game);
                            _autocompleteSearchDictionary.Add(stringBuilder.ToString(), currentListTemp);
                        }

                        foreach (char character in otherWord)
                        {
                            stringBuilder.Append(character);

                            List<Game> currentList;

                            bool success = _autocompleteSearchDictionary.TryGetValue(stringBuilder.ToString(), out currentList);

                            if (success)
                            {
                                currentList.Add(game);
                            }
                            else
                            {
                                currentList = new List<Game>();
                                currentList.Add(game);
                                _autocompleteSearchDictionary.Add(stringBuilder.ToString(), currentList);
                            }
                        }
                    }
                }
            }
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
            autocompleteSearchDictionaryNeedsUpdated = true;

            return true;
        }
    }
}
