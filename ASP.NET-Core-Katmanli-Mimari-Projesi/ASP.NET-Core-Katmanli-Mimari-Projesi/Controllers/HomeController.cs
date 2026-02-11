using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Katmanli_Mimari_Projesi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
