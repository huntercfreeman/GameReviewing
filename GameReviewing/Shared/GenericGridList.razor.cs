using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Shared
{
    public partial class GenericGridList<TItem> : ComponentBase
    {
        [Parameter]
        public List<TItem> Items { get; set; }
        [Parameter]
        public RenderFragment NullTemplate { get; set; }
        [Parameter]
        public RenderFragment EmptyTemplate { get; set; }
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }
    }
}
