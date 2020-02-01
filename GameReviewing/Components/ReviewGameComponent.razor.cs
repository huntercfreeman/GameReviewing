using GameReviewing.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Components
{
    public partial class ReviewGameComponent : ComponentBase
    {
        [Inject]
        public UserState UserState { get; set; }

        [Parameter]
        public Game Game { get; set; }
        [Parameter]
        public GameReviewing.Pages.Index Parent { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; }

        private double _left;
        public double Left 
        {
            get => _left;
            set
            {
                _left = value;
                StateHasChanged();
            }
        }

        private double _top;
        public double Top
        {
            get => _top;
            set
            {
                _top = value + 38;
                if (_top < 0)
                    _top = 0;

                StateHasChanged();
            }
        }
        


        protected override void OnInitialized()
        {
            base.OnInitialized();
            Parent.ReviewGameComponent = this;
        }

        public void LeaveReview()   
        {
            Review review = new Review
            {
                Rating = Rating,
                Description = Description,
                UserUsername = UserState.Username 
            };

            Game.AddReview(review);
            
            Parent.PublicStateHasChanged();
        }
    }
}
