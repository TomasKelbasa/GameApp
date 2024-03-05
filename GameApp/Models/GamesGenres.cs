using System.ComponentModel.DataAnnotations;

namespace GameApp.Models
 
{
    public class GamesGenres
    {
        [Key]
        public int GameId { get; set; }
        public Game Game { get; set; }
        [Key]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
