using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfReportGeneratorAPI.Models;
using PdfReportGeneratorAPI.Services;

namespace PdfReportGeneratorAPI.Controllers
{
    [Route("api/pdf/generate")]
    [ApiController]
    public class GeneratePDFController : ControllerBase
    {
        private readonly IPdfGeneratorService pdfGeneratorService;
        private readonly IWebHostEnvironment env;

        public GeneratePDFController(IPdfGeneratorService pdfGeneratorService, IWebHostEnvironment env)
        {
            this.pdfGeneratorService = pdfGeneratorService;
            this.env = env;
        }

        [HttpPost("invoice")]
        public async Task<IActionResult> GetInvoice([FromBody] Invoice invoice)
        {
            try { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var templatePath = Path.Combine(env.ContentRootPath, "Templates", "InvoiceTemplate.html");
            if(!System.IO.File.Exists(templatePath)) {
              return NotFound("Can not find the Template for Invoice");
            }
            var templateContent = await System.IO.File.ReadAllTextAsync(templatePath);

            var pdfReturnedFromService = await pdfGeneratorService.GeneratePdfAsync<Invoice>(invoice, templateContent);

            return File(pdfReturnedFromService, "application/pdf", "Invoice.pdf");
            }
            catch (Exception ex) {
                return StatusCode(500, $"Error generating PDF: {ex.Message}");
            }
        }
        [HttpPost("letter")]
        public async Task<IActionResult> GetLetter([FromBody] Letter letter)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var templatePath = Path.Combine(env.ContentRootPath, "Templates", "LetterTemplate.html");
                if (!System.IO.File.Exists(templatePath))
                {
                    return NotFound("Can not find the Template for Letter");
                }
                var templateContent = await System.IO.File.ReadAllTextAsync(templatePath);

                var pdfReturnedFromService = await pdfGeneratorService.GeneratePdfAsync<Letter>(letter, templateContent);

                return File(pdfReturnedFromService, "application/pdf", "Letter.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating PDF: {ex.Message}");
            }
        }
    }
}
