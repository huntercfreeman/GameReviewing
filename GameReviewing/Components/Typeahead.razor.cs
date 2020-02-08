using GameReviewing.Models;
using GameReviewing.Services.Interfaces;
using Microsoft.AspNetCore.Components;
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
        public List<Game> AutocompleteResults { get; set; }

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
    }
}
