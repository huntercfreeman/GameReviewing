using GameReviewing.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Components
{
    public partial class ReviewRenderer : ComponentBase
    {
        [Parameter]
        public Review Review { get; set; }
        [Parameter]
        public Game Game { get; set; }
    }
}
