using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Start_Bootstrap.Back_End.DAL;
using Start_Bootstrap.Back_End.Models;
using System.Threading.Tasks;

namespace Start_Bootstrap.Back_End.ViewComponents
{
    public class FooterViewComponent :ViewComponent
    {
        private readonly AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Setting setting = await _context.Settings.FirstOrDefaultAsync();
            return View(setting);
        }
    }
}
