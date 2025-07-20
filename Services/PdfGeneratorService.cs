using PuppeteerSharp;
using PuppeteerSharp.Media;
using Scriban;

namespace PdfReportGeneratorAPI.Services
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        public async Task<byte[]> GeneratePdfAsync<T>(T model, string template)
        {
            var parsedTemplate = Template.Parse(template);
            var htmlContent = parsedTemplate.Render(model, member => member.Name);

            // Download Chromium browser if not already downloaded
            var browserFetcher = new BrowserFetcher();
            var revisionInfo = await browserFetcher.DownloadAsync();

            var launchOptions = new LaunchOptions
            {
                Headless = true,
                ExecutablePath = revisionInfo.GetExecutablePath(),
                Args = new[]
                {
                    "--no-sandbox",
                    "--disable-setuid-sandbox"
                }
            };

            await using var browser = await Puppeteer.LaunchAsync(launchOptions);
            await using var page = await browser.NewPageAsync();

            await page.SetContentAsync(htmlContent);

            var pdfBytes = await page.PdfDataAsync(new PdfOptions
            {
                Format = PaperFormat.A4,
                PrintBackground = true
            });

            return pdfBytes;
        }
    }
}
