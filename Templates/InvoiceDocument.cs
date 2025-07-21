namespace PdfReportGeneratorAPI.Templates
{
    using QuestPDF.Fluent;
    using QuestPDF.Helpers;
    using QuestPDF.Infrastructure;
    using QuestPDF.Drawing;
    using PdfReportGeneratorAPI.Models;

    public class InvoiceDocument : IDocument
    {
        private readonly Invoice _invoice;

        public InvoiceDocument(Invoice invoice)
        {
            _invoice = invoice;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(40);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(12).FontFamily("Arial"));

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Line("If you have any questions about this invoice, please contact:");
                        text.Line(_invoice.ContactInfo);
                    });
                });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(_invoice.CompanyName).Bold();
                    col.Item().Text(_invoice.CompanyStreet);
                    col.Item().Text(_invoice.CompanyCityZip);
                    col.Item().Text($"Phone: {_invoice.CompanyPhone}");
                    col.Item().Text($"Fax: {_invoice.CompanyFax}");
                    col.Item().Text(_invoice.CompanyWebsite);
                });

                row.RelativeItem().AlignRight().Column(col =>
                {
                    col.Item().Text($"Invoice Date: {_invoice.InvoiceDate}");
                    col.Item().Text($"Invoice #: {_invoice.InvoiceNumber}");
                    col.Item().Text($"Customer ID: {_invoice.CustomerId}");
                    col.Item().Text($"Due Date: {_invoice.DueDate}");
                });
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(10).Column(column =>
            {
                column.Spacing(15);

                // Bill To
                column.Item().Text("Bill To:").Bold();
                column.Item().Text($"{_invoice.ClientName}");
                column.Item().Text($"{_invoice.ClientCompany}");
                column.Item().Text($"{_invoice.ClientStreet}");
                column.Item().Text($"{_invoice.ClientCityZip}");
                column.Item().Text($"Phone: {_invoice.ClientPhone}");

                // Items Table
                column.Item().Text("Items:").Bold();
                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.ConstantColumn(60);
                        columns.ConstantColumn(80);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Text("Description").Bold();
                        header.Cell().Element(CellStyle).Text("Taxed").Bold();
                        header.Cell().Element(CellStyle).AlignRight().Text("Amount").Bold();
                    });

                    foreach (var item in _invoice.Items)
                    {
                        table.Cell().Element(CellStyle).Text(item.Description);
                        table.Cell().Element(CellStyle).Text(item.IsTaxed ? "Yes" : "No");
                        table.Cell().Element(CellStyle).AlignRight().Text($"${item.Amount:F2}");
                    }

                    static IContainer CellStyle(IContainer container) =>
                        container.Border(1).Padding(5);
                });

                // Summary Table
                column.Item().PaddingTop(20).Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.RelativeColumn();
                        c.ConstantColumn(100);
                    });

                    table.Cell().AlignRight().Text("Subtotal:");
                    table.Cell().AlignRight().Text($"${_invoice.Subtotal:F2}");

                    table.Cell().AlignRight().Text("Taxable Amount:");
                    table.Cell().AlignRight().Text($"${_invoice.TaxableAmount:F2}");

                    table.Cell().AlignRight().Text("Tax Rate:");
                    table.Cell().AlignRight().Text($"{_invoice.TaxRate:P}");

                    table.Cell().AlignRight().Text("Tax Due:");
                    table.Cell().AlignRight().Text($"${_invoice.TaxDue:F2}");

                    table.Cell().AlignRight().Text("Other Charges:");
                    table.Cell().AlignRight().Text($"${_invoice.OtherCharges:F2}");

                    table.Cell().AlignRight().Text("Total:").Bold();
                    table.Cell().AlignRight().Text($"${_invoice.Total:F2}").Bold();
                });

                // Comments
                if (_invoice.OtherComments?.Any() == true)
                {
                    column.Item().PaddingTop(20).Text("Other Comments:").Bold();
                    foreach (var comment in _invoice.OtherComments)
                    {
                        column.Item().Text($"• {comment}");
                    }
                }
            });
        }
    }

}
