using GameApp.Data;
using GameApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameApp.Pages
{
    public class GamesModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<Game> Games { get; set; }

        public GamesModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Games = _context.Games.ToList();
        }
    }
}
