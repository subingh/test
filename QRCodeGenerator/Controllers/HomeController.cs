using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.Helper.QRCodeGenerator;
using QRCodeGenerator.Models;
using QRCodeGenerator.ViewModels;
using System.Diagnostics;

namespace QRCodeGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQRCodeGenerator qRCodeGenerator;

        public HomeController(ILogger<HomeController> logger, IQRCodeGenerator qRCodeGenerator)
        {
            _logger = logger;
            this.qRCodeGenerator = qRCodeGenerator;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string text)
        {
            Payload? payload = null;
            if (string.IsNullOrEmpty(text))
                return BadRequest();
            byte[] QRCodeAsBytes = qRCodeGenerator.GenerateQRCode(text);
            string QRCodeAsImageBase64 = $"data:image/png;base64,{Convert.ToBase64String(QRCodeAsBytes)}";
            GenerateQRCodeViewModel model = new GenerateQRCodeViewModel();
            model.QRCodeText = QRCodeAsImageBase64;
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
