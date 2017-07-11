using System.ComponentModel.DataAnnotations;

namespace Fiver.Api.Help.Models.Movies
{
    public class MovieInputModel
    {
        [Required]
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Summary { get; set; }
    }
}
