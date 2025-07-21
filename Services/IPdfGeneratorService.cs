namespace PdfReportGeneratorAPI.Services
{
    public interface IPdfGeneratorService
    {
        byte[] GeneratePdfFromModel(object model);
    }
}
