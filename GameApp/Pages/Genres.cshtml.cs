using GameApp.Data;
using GameApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Pages
{
    public class GenresModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<Genre> Genres { get; set; }

        public GenresModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Genres = _context.Genres.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            Console.WriteLine(id);
            var genre = _context.Genres.FirstOrDefault(g => g.GenreID == id);
            if (genre == null) return BadRequest(ModelState);
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            Genres = _context.Genres.ToList();
            return Page();
        }

        public IActionResult OnPostAdd(Genre genre)
        {
            if (genre == null || genre.Name == null) return BadRequest(ModelState);
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}
