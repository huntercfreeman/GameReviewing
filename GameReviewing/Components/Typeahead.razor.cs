using GameReviewing.Models;
using GameReviewing.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Components
{
    public partial class Typeahead : ComponentBase
    {
        [Inject]
        public IGameService GameService { get; set; }

        [Parameter]
        public EventCallback<List<Game>> OnAutocomplete { get; set; }
        [Parameter]
        public EventCallback<List<Game>> OnSearch { get; set; }
        // if autocomplete was calculated before search was clicked and they share the same
        // searching they'll return the same list so just return the autocomplete list
        // instead of searching.
        [Parameter]
        public bool ResultsAreSame { get; set; }
        [Parameter]
        public bool DisplayAutocompleteDropdown { get; set; }
        [Parameter]
        public RenderFragment<Game> AutocompleteDropdownItemTemplate { get; set; }

        public List<Game> AutocompleteResults { get; set; } = new List<Game>();

        private List<Game> _searchResults;
        public List<Game> SearchResults 
        {
            get 
            {
                if (ResultsAreSame)
                {
                    return AutocompleteResults;
                }
                else
                {
                    return _searchResults;
                }
            }
            set => _searchResults = value;
        }

        private string _searchParameter;
        public string SearchParameter 
        {
            get => _searchParameter;
            set
            {
                _searchParameter = value;
                Autocomplete();
            }
        }

        public void Autocomplete()
        {
            AutocompleteResults = GameService.GetGamesByTitle(SearchParameter);
            OnAutocomplete.InvokeAsync(AutocompleteResults);
        }

        public void Search()
        {
            if(!ResultsAreSame)
            {
                SearchResults = GameService.GetGamesByTitle(SearchParameter);
                OnSearch.InvokeAsync(AutocompleteResults);
            }
        }

        public void FocusIn()
        {
            Console.WriteLine("Focus In");
        }

        public void FocusOut()
        {
            Console.WriteLine("Focus Out");
        }

        public void OnKeyDown(KeyboardEventArgs e)
        {
            Console.WriteLine($"AltKey:{e.AltKey}\nCode:{e.Code}\nCtrlKey:{e.CtrlKey}\nKey:{e.Key}" +
                $"\nLocation:{e.Location}\nMetaKey:{e.MetaKey}\nRepeat:{e.Repeat}\nShiftKey:{e.ShiftKey}\nType:{e.Type}");
        }

        public void OnKeyUp(KeyboardEventArgs e)
        {
            // Holding key down will call OnKeyDown multiple times no need to do what I thought I needed to do to implement OnKeyHoldDown logic.
            Console.WriteLine($"AltKey:{e.AltKey}\nCode:{e.Code}\nCtrlKey:{e.CtrlKey}\nKey:{e.Key}" +
                $"\nLocation:{e.Location}\nMetaKey:{e.MetaKey}\nRepeat:{e.Repeat}\nShiftKey:{e.ShiftKey}\nType:{e.Type}");
        }
    }
}
