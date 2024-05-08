using System.ComponentModel.DataAnnotations;

namespace QRCodeGenerator.ViewModels
{
    public class GenerateQRCodeViewModel
    {
        [Display(Name = "Enter text here")]
        public string QRCodeText { get; set; }
    }
}
