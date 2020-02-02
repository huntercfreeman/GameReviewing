using GameReviewing.Models;
using GameReviewing.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
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
        public EventCallback OnReviewAdded { get; set; }

        public bool Show { get; set; }
        public ReviewGameViewModel Review { get; set; } = new ReviewGameViewModel() { Rating = 1 };

        public EditContext EditContext { get; set; }

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
            EditContext = new EditContext(Review);
        }

        public void LeaveReview()   
        {
            Review review = new Review
            {
                Rating = Review.Rating,
                Description = Review.Description,
                UserUsername = UserState.Username 
            };

            Game.AddReview(review);

            Show = false;

            StateHasChanged();

            OnReviewAdded.InvokeAsync(this);
        }

        public void ReviewGame(MouseEventArgs e)
        {
            Show = true;

            Left = e.ClientX;
            Top = e.ClientY;
        }
    }
}
