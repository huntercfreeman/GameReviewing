using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Title { get; set; }

        private List<Review> _reviews { get; set; }

        public List<Review> Reviews 
        {
            set 
            {
                _reviews = value;
                Rating = _reviews.Average(x => x.Rating);
            } 
        }

        private double _rating;
        public double Rating 
        { 
            get
            {
                return (double)decimal.Round((decimal)_rating, 2, MidpointRounding.AwayFromZero); ;
            }
            set
            {
                _rating = value;
            }
        }

        public string ImagePath { get; set; }

        public void AddReview(Review review)
        {
            _reviews.Add(review);

            Rating = _reviews.Average(x => x.Rating);
        }

        public List<Review> GetReviews()
        {
            return _reviews;
        }
    }
}
