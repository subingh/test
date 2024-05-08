namespace QRCodeGenerator.Helper.QRCodeGenerator
{
    public interface IQRCodeGenerator
    {
        byte[] GenerateQRCode(string text);
    }
}
