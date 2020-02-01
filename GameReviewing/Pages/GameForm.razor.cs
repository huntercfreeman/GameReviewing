using GameReviewing.Models;
using GameReviewing.Services.Interfaces;
using GameReviewing.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
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
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public Game GameParameter { get; set; }
        [Parameter]
        public int Id { get; set; }

        public GameFormViewModel Game { get; set; }
        public Game GameFromId { get; set; }
        public EditContext EditContext { get; set; }

        public bool Adding { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            NavigationManager.LocationChanged += NavigationManager_LocationChanged;

            if (Id != 0)
            {
                GameFromId = GameService.GetGameById(Id);

                if(!(GameFromId.Id == 0))
                {
                    Game = new GameFormViewModel { Title = GameFromId.Title };
                }
                else
                {
                    Game = new GameFormViewModel { Title = "Error game with Id:" + Id + " was not found" };
                }
            }
            else if (GameParameter != null)
            {
                Game = new GameFormViewModel() { Title = GameParameter.Title };
            }
            else
            {
                Adding = true;
                Game = new GameFormViewModel();
            }

            EditContext = new EditContext(Game);
        }

        private void NavigationManager_LocationChanged(object sender, Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs e)
        {
            // When going from editing a game to adding a game the page goes from
            // /game/edit/1 ---> /game/add the route changes but both routes lead
            // to GameForm.razor so nothing changes. The page is therefore manually
            // reloaded.
            JSRuntime.InvokeVoidAsync("LocationReload");
        }

        public void OnSubmit()
        {
            if(Id != 0)
            {
                GameFromId.Title = Game.Title;
            }
            else if(GameParameter != null)
            {
                GameParameter.Title = Game.Title;
            }
            else
            {
                GameService.AddGame(new Game { Id = GameService.NextId, Title = Game.Title });
            }
        }

        public void ImageSelected()
        {

        }
    }
}
