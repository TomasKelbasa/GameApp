namespace GameApp.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
