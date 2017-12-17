using System;
using System.ComponentModel.DataAnnotations;
using RazorPagesTest.DataLayer.Models;

namespace RazorPagesTest.Web.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [StringLength(5)]
        [Required]
        public string Rating { get; set; }

        public static MovieModel FromMovie(Movie movie)
        {
            if (movie == null)
            {
                return null;
            }

            return new MovieModel
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                Genre = movie.Genre,
                Price = movie.Price,
                Rating = movie.Rating
            };
        }

        public Movie ToMovie()
        {
            return new Movie
            {
                Id = Id,
                Title = Title,
                ReleaseDate = ReleaseDate,
                Genre = Genre,
                Price = Price,
                Rating = Rating
            };
        }
    }
}