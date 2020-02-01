using GameReviewing.Models;
using GameReviewing.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Pages
{
    public partial class GameDetails : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IGameService GameService { get; set; }

        public Game ThisGame { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            ThisGame = GameService.GetGameById(Id);
        }
    }
}
