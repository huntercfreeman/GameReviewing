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

        public bool ToggleAutocompleteDropdown { get; set; }

        private List<Game> _autocompleteResults;
        public List<Game> AutocompleteResults 
        {
            get => _autocompleteResults;
            set
            {
                CurrentIndex = 0;
                _autocompleteResults = value;
                StateHasChanged();
            }
        }

        public int CurrentIndex { get; set; }

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

        protected override void OnInitialized()
        {
            base.OnInitialized();
            AutocompleteResults = new List<Game>();
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
            ToggleAutocompleteDropdown = true;
        }

        public void FocusOut()
        {
            ToggleAutocompleteDropdown = false;
        }

        public void OnKeyDown(KeyboardEventArgs e)
        {
            if (e.Key == "ArrowUp")
            {
                CurrentIndex--;

                if (CurrentIndex < 0)
                    CurrentIndex = AutocompleteResults.Count - 1;

                StateHasChanged();
            }
            else if (e.Key == "ArrowDown")
            {
                CurrentIndex++;

                if (CurrentIndex == AutocompleteResults.Count)
                    CurrentIndex = 0;

                StateHasChanged();
            }
            else if (e.Key == "Enter")
            {
                SearchParameter = AutocompleteResults[CurrentIndex].Title;

                StateHasChanged();
            }
        }
    }
}
