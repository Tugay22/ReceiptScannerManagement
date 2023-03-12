using ReceiptScannerManagement.Models;

namespace ReceiptScannerManagement.Services.Abstract
{
    public interface IReceiptScannerService
    {
        string ReceiptScan(List<Receipt> receipts);
    }
}
