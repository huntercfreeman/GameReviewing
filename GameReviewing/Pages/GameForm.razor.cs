using GameReviewing.Models;
using GameReviewing.Services.Interfaces;
using GameReviewing.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Pages
{
    public partial class GameForm : ComponentBase
    {
        [Inject]
        public IGameService GameService { get; set; }
        [Parameter]
        public Game GameParameter { get; set; }
        [Parameter]
        public int Id { get; set; }

        public GameFormViewModel Game { get; set; }
        public EditContext EditContext { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            
            if (Id != 0)
            {
                Game gameFromId = GameService.GetGameById(Id);

                if(!(gameFromId.Id == 0))
                {
                    Game = new GameFormViewModel { Title = gameFromId.Title };
                }
                else
                {
                    Game = new GameFormViewModel { Title = "Error game with Id:" + Id + " was not found" };
                }
            }
            else if (GameParameter == null)
            {
                Game = new GameFormViewModel();
            }
            else
            {
                Game = new GameFormViewModel() { Title = GameParameter.Title };
            }

            EditContext = new EditContext(Game);
        }

        public void OnSubmit()
        {

        }

        public void ImageSelected()
        {

        }
    }
}
