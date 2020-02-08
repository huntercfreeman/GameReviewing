using GameReviewing.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Components
{
    public partial class TypeaheadAutocompleteDropdownItem : ComponentBase
    {
        [Parameter]
        public Typeahead Parent { get; set; }
        [Parameter]
        public int MyIndex { get; set; }
        [Parameter]
        public Game Self { get; set; }

        public string HoveredCSS 
        {
            get => Parent.CurrentIndex == MyIndex ? "background-color: blue;" : "";
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
