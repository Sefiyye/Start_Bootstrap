using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Start_Bootstrap.Back_End.DAL;
using Start_Bootstrap.Back_End.ViewModels;
using System.Threading.Tasks;

namespace Start_Bootstrap.Back_End.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM
            {
                Cards = await _context.Cards.ToListAsync(),
                MainParts = await _context.MainParts.FirstOrDefaultAsync(),
                Abouts = await _context.Abouts.FirstOrDefaultAsync(),
                Settings = await _context.Settings.FirstOrDefaultAsync(),
                SocialMedias = await _context.SocialMedias.ToListAsync()
            };
            return View(model);
        }
    }
}
