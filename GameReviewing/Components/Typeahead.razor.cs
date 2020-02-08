using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Components
{
    public partial class Typeahead : ComponentBase
    {
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
            Console.WriteLine($"Autocomplete {SearchParameter}");
        }

        public void Search()
        {
            Console.WriteLine($"Search {SearchParameter}");
        }
    }
}
