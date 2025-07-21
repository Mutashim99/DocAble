
using PdfReportGeneratorAPI.Models;
using PdfReportGeneratorAPI.Templates;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace PdfReportGeneratorAPI.Services
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        public byte[] GeneratePdfFromModel(object model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            IDocument document;
            if (model is Invoice invoice)
            {
                document = new InvoiceDocument(invoice);
            }
            else if (model is Letter letter)
            {
                document = new LetterDocument(letter);
            }
            else
            {
                throw new InvalidOperationException("Unsupported document type.");
            }


            return document.GeneratePdf();
        }
    }
}
