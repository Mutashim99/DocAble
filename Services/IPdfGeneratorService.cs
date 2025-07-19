namespace PdfReportGeneratorAPI.Services
{
    public interface IPdfGeneratorService
    {
        Task<Byte[]> GeneratePdfAsync<T>(T model, string template);
    }
}
