using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Start_Bootstrap.Back_End.DAL;
using Start_Bootstrap.Back_End.Extensions;
using Start_Bootstrap.Back_End.Models;
using Start_Bootstrap.Back_End.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Start_Bootstrap.Back_End.Areas.Start_BootstrapAdmin.Controllers
{
    [Area("Start_BootstrapAdmin")]
    public class CardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CardController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Card> cards = await _context.Cards.ToListAsync();
            return View(cards);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Detail(int id)
        {
            Card card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (card == null) return NotFound();

            return View(card);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Card card)
        {
            if (!ModelState.IsValid) return View();
            if (card.Photo != null)
            {
                if (!card.Photo.IsOkay(1))
                {
                    card.Image = await card.Photo.FileCreate(_env.WebRootPath, @"assets\img");
                    await _context.AddAsync(card);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Photo", "Please, choose image file under the 1 mb");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Photo", "Please,choose file");
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            Card card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (card == null) return NotFound();
            return View(card);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Card card)
        {
            if (!ModelState.IsValid) return View();
            Card existedCard = await _context.Cards.FirstOrDefaultAsync(p => p.Id == id);
            if (card.Photo != null)
            {
                if (!card.Photo.IsOkay(1))
                {
                    string path = _env.WebRootPath + @"assets\img" + existedCard.Image;
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    existedCard.Image = await card.Photo.FileCreate(_env.WebRootPath, @"assets\img");
                }
                else
                {
                    ModelState.AddModelError("Photo", "Please,choose photo under the 1 mb");
                    return View();
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    public async Task<IActionResult> Delete(int id)
        {
            Card card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (card == null) return NotFound();
            return View(card);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> Deletecard(int id)
        {
            Card card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
