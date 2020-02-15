using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Components
{
    public partial class Star : ComponentBase
    {
        [Parameter]
        public double Percentage { get; set; }
    }
}
