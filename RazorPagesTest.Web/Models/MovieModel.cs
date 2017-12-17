using System;
using System.ComponentModel.DataAnnotations;
using RazorPagesTest.DataLayer.Models;

namespace RazorPagesTest.Web.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

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
                Price = movie.Price
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
                Price = Price
            };
        }
    }
}