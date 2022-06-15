using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Start_Bootstrap.Back_End.DAL;
using Start_Bootstrap.Back_End.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Start_Bootstrap.Back_End.Areas.Start_BootstrapAdmin.Controllers
{
    [Area("Start_BootstrapAdmin")]
    public class CardController : Controller
    {
        private readonly AppDbContext _context;

        public CardController(AppDbContext context)
        {
            _context = context;
            
        }
        public async Task<IActionResult> Index()
        {
            List<Card> cards = await _context.Cards.ToListAsync();
            
            return View(cards);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
       public async Task<IActionResult> Create(Card card)
        {
            if (!ModelState.IsValid) return View();
            await _context.AddAsync(card);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Detail(int id)
        {
            Card cards = await _context.Cards.FirstOrDefaultAsync(c=>c.Id==id);
            return View(cards);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Card card)
        {
            Card existedcard = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (existedcard == null) return NotFound();

            if (existedcard.Id != id) return BadRequest();

            existedcard.Id = card.Id;
            existedcard.Image = card.Image;
            existedcard.Icon = card.Icon;
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
        public async Task<IActionResult> DeleteCart(int id)
        {
            Card card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
