using GameApp.Data;
using GameApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Pages
{
    public class EditGameModel : PageModel
    {
        private readonly AppDbContext _context;
        public Game Game { get; set; }
        public List<Genre> AllGenres { get; set; }

        public EditGameModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            if (_context.Games == null) return BadRequest(ModelState);
            var g = _context.Games.Include(g => g.Genres).FirstOrDefault(g => g.GameID == id);
            var genres = _context.Genres;
            if (g == null) return BadRequest(ModelState);
            else
            {
                Game = g;
                AllGenres = genres.ToList();
                return Page();
            }
        }

        public IActionResult OnPostChangeData(Game game, List<int> genres) {

            Console.WriteLine(genres.Count);

            if (game == null || game.Name == null) return BadRequest(ModelState);
            Console.WriteLine(game.Name);
            Game = _context.Games.Include(g => g.Genres).First(a => a.GameID == game.GameID);

            AllGenres = _context.Genres.ToList();
            if(Game == null) return BadRequest(ModelState);

            var GamesGenres = _context.GamesGenres;
            foreach (var gg in GamesGenres)
            {
                if(gg.GameId == game.GameID)
                {
                    GamesGenres.Remove(gg);                  
                }
            }

            Console.WriteLine(genres.Count);

            foreach (var genre in genres)
            {

                Console.WriteLine("Adding");
                GamesGenres.Add(new GamesGenres { GameId = game.GameID, GenreId = genre });
                
            }


            Game.Genres = AllGenres.Where((a) => genres.Contains(a.GenreID)).ToList();
            Console.WriteLine(game.Name);
            Game.Name = game.Name;
            Game.Url = game.Url;
            Game.Description = game.Description;
            _context.Games.Update(Game);
            _context.SaveChanges();

            return RedirectToPage("Games");
        }
    }
}
