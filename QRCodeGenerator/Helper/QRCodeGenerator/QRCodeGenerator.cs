using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;

namespace QRCodeGenerator.Helper.QRCodeGenerator
{
    public class QRCodeGenerator : IQRCodeGenerator
    {
        [HttpPost]
        public IActionResult CreateQRCode(string text)
        {
            byte[] QRCode = null;
            if (!string.IsNullOrEmpty(text))
            {
                QRCodeGenerator QrGenerator = new QRCodeGenerator();
                QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                BitmapByteQRCode bitmap = new BitmapByteQRCode();
                QRCode = bitmap.GetGraphic(60);
                byte[] BitmapArray = bitmap.qRCodeGenerator.(text);
                string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
                ViewBag.QrCodeUri = QrUri;
            }

            return View();
        }


        private QRCodeData CreateQrCode(string text, object q)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            return qrGenerator.CreateQrCode(text, ECCLevel.Q);
        }
    }
}

