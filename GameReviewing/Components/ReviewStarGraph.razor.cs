using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Components
{
    public partial class ReviewStarGraph : ComponentBase
    {
        [Parameter]
        public double Rating { get; set; }
        [Parameter]
        public double Max { get; set; }
    }
}
