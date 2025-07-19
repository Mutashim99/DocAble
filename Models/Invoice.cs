namespace PdfReportGeneratorAPI.Models
{
    public class Invoice
    {
        public string CompanyName { get; set; }
        public string CompanyStreet { get; set; }
        public string CompanyCityZip { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyWebsite { get; set; }

        public string InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string CustomerId { get; set; }
        public string DueDate { get; set; }

        public string ClientName { get; set; }
        public string ClientCompany { get; set; }
        public string ClientStreet { get; set; }
        public string ClientCityZip { get; set; }
        public string ClientPhone { get; set; }

        
        public List<InvoiceItem> Items { get; set; }

        public decimal Subtotal { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxDue { get; set; }
        public decimal OtherCharges { get; set; }
        public decimal Total { get; set; }

        public List<string> OtherComments { get; set; }
        
        public string ContactInfo { get; set; } // Name, phone, email
    }
}
