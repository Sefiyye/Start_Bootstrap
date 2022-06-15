using Microsoft.AspNetCore.Mvc;

namespace Start_Bootstrap.Back_End.Areas.Start_BootstrapAdmin.Controllers
{
    [Area("Start_BootstrapAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
