using Microsoft.AspNetCore.Mvc;
using ReceiptScannerManagement.Models;
using ReceiptScannerManagement.Services.Abstract;

namespace ReceiptScannerManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceiptScannerController : ControllerBase
    {
        private readonly IReceiptScannerService _receiptScannerService;

        public ReceiptScannerController(IReceiptScannerService receiptScannerService)
        {
            this._receiptScannerService = receiptScannerService;
        }

        [HttpPost("ReceiptScan")]
        public async Task<IActionResult> ReceiptScan(List<Receipt> receipt)
        {
            string result = _receiptScannerService.ReceiptScan(receipt);
            return Ok(result);
        }
    }
}