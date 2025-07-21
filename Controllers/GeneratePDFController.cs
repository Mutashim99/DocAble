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
        public IActionResult GenerateInvoicePdf([FromBody] Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Incorrect Format");
            }
            var pdfBytes = pdfGeneratorService.GeneratePdfFromModel(invoice);
            return File(pdfBytes, "application/pdf", "invoice.pdf");
        }

        [HttpPost("letter")]
        public IActionResult GenerateLetterPdf([FromBody] Letter letter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Incorrect Format");
            }
            var pdfBytes = pdfGeneratorService.GeneratePdfFromModel(letter);
            return File(pdfBytes, "application/pdf", "letter.pdf");
        }
    }
}
