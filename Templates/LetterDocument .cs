namespace PdfReportGeneratorAPI.Templates
{
    using QuestPDF.Fluent;
    using QuestPDF.Helpers;
    using QuestPDF.Infrastructure;
    using PdfReportGeneratorAPI.Models;

    public class LetterDocument : IDocument
    {
        private readonly Letter _letter;

        public LetterDocument(Letter letter)
        {
            _letter = letter;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(50);
                page.Size(PageSizes.A4);
                page.DefaultTextStyle(x => x.FontSize(14).FontFamily("Times New Roman"));

                page.Content()
                    .Column(column =>
                    {
                        column.Spacing(20);

                        // Sender Block  
                        column.Item().Text(text =>
                        {
                            text.Line(_letter.SenderName);
                            text.Line(_letter.SenderTitle);
                            text.Line(_letter.SenderCompany);
                            text.Line(_letter.SenderAddress);
                        });

                        // Date  
                        column.Item().Text(_letter.Date).FontSize(14);

                        // Recipient Block  
                        column.Item().Text(text =>
                        {
                            text.Line(_letter.RecipientName);
                            text.Line(_letter.RecipientTitle);
                            text.Line(_letter.RecipientCompany);
                            text.Line(_letter.RecipientAddress);
                        });

                        // Subject  
                        column.Item().Text($"Subject: {_letter.Subject}")
                            .Bold()
                            .Underline()
                            .FontSize(14);

                        // Body  
                        column.Item().Text(_letter.Body)
                            .FontSize(14)
                            .LineHeight(1.6f)
                            .AlignLeft(); // Corrected  

                        // Closing  
                        column.Item().PaddingTop(20).Text($"{_letter.Closing},")
                            .FontSize(14);

                        // Signature  
                        column.Item().PaddingTop(20).Text(text =>
                        {
                            text.Line(_letter.SignatureName);
                            text.Line(_letter.SignatureTitle);
                        });
                    });
            });
        }
    }
}
