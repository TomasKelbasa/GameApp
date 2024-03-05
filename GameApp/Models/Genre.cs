namespace GameApp.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
