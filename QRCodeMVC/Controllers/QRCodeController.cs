using Microsoft.AspNetCore.Mvc;
using QRCodeMVC.Models;
using QRCoder;
using static QRCoder.PayloadGenerator;

namespace QRCodeMVC.Controllers
{
    public class QRCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(QRCodeModel model)
        {
            Payload? payload = null;
            payload = new WhatsAppMessage(model.Text);
            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload);
            BitmapByteQRCode qrCode = new(qrCodeData);
            string base64String = Convert.ToBase64String(qrCode.GetGraphic(20));
            model.QRImageURL = "data:image/png;base64," + base64String;
            return View("Index", model);
        }

    }
}
