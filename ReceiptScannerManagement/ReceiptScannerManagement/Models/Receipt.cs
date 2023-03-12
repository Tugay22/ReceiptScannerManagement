namespace ReceiptScannerManagement.Models
{
    public class Receipt
    {
        public string? Locale { get; set; }
        public string Description { get; set; }
        public BoundingPoly BoundingPoly { get; set; }
    }
}
