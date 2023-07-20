using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppCalculator.Models;

namespace WebAppCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        IEnumerable<OperationModel> operations = new List<OperationModel>
        {
            new OperationModel { Sign = '+', Name = "Сложение" },
            new OperationModel { Sign = '-', Name = "Вычитание" }
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}