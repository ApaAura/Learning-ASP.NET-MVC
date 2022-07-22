using WebAppFirst.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WebAppFirst.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }

        [Display(Name = "Data realizarii")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Stoc disponibil")]
        [Range(1, 20)]
        [Required]
        public int? NumberInStock { get; set; }
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.Released;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreID;
        }
    }
}
