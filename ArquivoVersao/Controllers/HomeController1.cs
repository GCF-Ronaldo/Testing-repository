using Microsoft.AspNetCore.Mvc;

namespace ArquivoVersao.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
