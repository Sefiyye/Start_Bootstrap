using Microsoft.AspNetCore.Mvc;

namespace Start_Bootstrap.Back_End.Areas.Start_BootstrapAdmin.Controllers
{
    [Area("Start_Bootstrap.Admin")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
