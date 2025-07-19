using PuppeteerSharp.Media;
using PuppeteerSharp;
using PuppeteerSharp.BrowserData;
using Scriban;

namespace PdfReportGeneratorAPI.Services
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        public async Task<byte[]> GeneratePdfAsync<T>(T model, string template)
        {
            // we are passing the string of html(converted into text) into Render but first we are pasrsing it
            // so that it can fill in all the placeholders using the Render(Model) method.
            var parsedTemplate = Template.Parse(template);
            var htmlContent = parsedTemplate.Render(model, member => member.Name);

            var browserDownloaded = false;

            if (!browserDownloaded)
            {
                var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync();
                browserDownloaded = true;
            }

            // launching browser(after downloading it)
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            }) ;

            
            await using var page = await browser.NewPageAsync(); // now we are setting the browser's page
                                                                 // content to the html content we made
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
