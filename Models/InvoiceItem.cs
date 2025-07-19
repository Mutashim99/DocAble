namespace PdfReportGeneratorAPI.Models
{
    public class InvoiceItem
    {
        public string Description { get; set; }
        public bool IsTaxed { get; set; }
        public decimal Amount { get; set; }
    }
}
