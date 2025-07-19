namespace PdfReportGeneratorAPI.Models
{
    public class Letter
    {
        public string SenderName { get; set; }
        public string SenderTitle { get; set; }
        public string SenderCompany { get; set; }
        public string SenderAddress { get; set; }

        public string RecipientName { get; set; }
        public string RecipientTitle { get; set; }
        public string RecipientCompany { get; set; }
        public string RecipientAddress { get; set; }

        public string Date { get; set; }          
        public string Subject { get; set; }

        public string Body { get; set; }         
        public string Closing { get; set; }       
        public string SignatureName { get; set; }
        public string SignatureTitle { get; set; }
    }
}
