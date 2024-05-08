using System.ComponentModel.DataAnnotations;

namespace QRGenerator.Models
{
    public class QRCodeModel
    {
        [Display(Name = "Enter QRCode Text")]
        public string QRCodeText { get; set; }
        public string QRImageURL {  get; set; }
    }
}
