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
using Blazor.FileReader;
using System.IO;
using System.Drawing;

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
        [Inject]
        public IFileReaderService FileReaderService { get; set; }

        [Parameter]
        public Game GameParameter { get; set; }
        [Parameter]
        public int Id { get; set; }

        public string ImageBase64 { get; set; }
        public byte[] ImageBytes { get; set; }

        public ElementReference InputElement { get; set; }
        public GameFormViewModel Game { get; set; }
        public Game GameFromId { get; set; }
        public EditContext EditContext { get; set; }

        public bool Adding { get; set; }
        public List<string> ImageValidationErrors { get; set; }
        public bool ShowImageValidationErrors { get; set; }

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
            ImageValidationErrors = new List<string>();
            ShowImageValidationErrors = false;

            if(Id != 0)
            {
                if(!string.IsNullOrWhiteSpace(ImageBase64))
                {
                    string newImagePath = GetNewImagePath();

                    if (!string.IsNullOrWhiteSpace(newImagePath))
                    {
                        GameFromId.Title = Game.Title;
                        GameFromId.ImagePath = newImagePath;
                    }
                    else
                    {
                        ShowImageValidationErrors = true;
                    }
                }
                else
                {
                    GameFromId.Title = Game.Title;
                }
            }
            else if(GameParameter != null)
            {
                if (!string.IsNullOrWhiteSpace(ImageBase64))
                {
                    string newImagePath = GetNewImagePath();

                    if (!string.IsNullOrWhiteSpace(newImagePath))
                    {
                        GameParameter.Title = Game.Title;
                        GameParameter.ImagePath = newImagePath;
                    }
                    else
                    {
                        ShowImageValidationErrors = true;
                    }
                }
                else
                {
                    GameParameter.Title = Game.Title;
                }
            }
            else
            {
                string newImagePath = GetNewImagePath();

                if(!string.IsNullOrWhiteSpace(newImagePath))
                {
                    GameService.AddGame(new Game { Id = GameService.NextId, Title = Game.Title, ImagePath = newImagePath });
                }
                else
                {
                    ShowImageValidationErrors = true;
                }
            }
            NavigationManager.NavigateTo("");
        }

        public async void ImageSelected()
        {
            foreach(var file in await FileReaderService.CreateReference(InputElement).EnumerateFilesAsync())
            {
                using (MemoryStream memoryStream = await file.CreateMemoryStreamAsync(4 * 1024))
                {
                    ImageBytes = new byte[memoryStream.Length];
                    memoryStream.Read(ImageBytes, 0, (int)memoryStream.Length);
                    ImageBase64 = Convert.ToBase64String(ImageBytes);
                    StateHasChanged();
                }
            }
        }

        //public string GetNewImagePath()
        //{
        //    string filePath = $"wwwroot/content/images/{Game.Title}-{Guid.NewGuid().ToString()}";
        //    using (var imageFile = new FileStream(filePath, FileMode.Create))
        //    {
        //        imageFile.Write(ImageBytes, 0, ImageBytes.Length);
        //        imageFile.Flush();
        //    }

        //    return filePath;
        //}

        public string GetNewImagePath()
        {
            string id = Guid.NewGuid().ToString();
            string filePath = $"wwwroot/content/images/{Game.Title}-{id}.png";

            using (var ms = new MemoryStream(ImageBytes, 0, ImageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);

                if(image.Width == 285 && image.Height == 380)
                {
                    image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    return $"content/images/{Game.Title}-{id}.png";
                }
                else
                {
                    ImageValidationErrors.Add("The image must be 285 x 380");
                    return "";
                }
            }
        }
    }
}
