using GameApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GameApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Pages
{
    public class GameDetailModel : PageModel
    {
        private readonly AppDbContext _context;
        public Game Game { get; set; }

        public GameDetailModel (ILogger<IndexModel> logger, AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            if (_context.Games == null) return BadRequest(ModelState);
            var g = _context.Games.Include(g => g.Genres).FirstOrDefault(g => g.GameID == id);
            if (g == null) return BadRequest(ModelState);
            else
            {
                Game = g;
                return Page();
            }
        }


    }
}
