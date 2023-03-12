using ReceiptScannerManagement.Models;
using ReceiptScannerManagement.Services.Abstract;
using System.Text;

namespace ReceiptScannerManagement.Services.Concerete
{
    /// <summary>
    /// Bu service gelen verticelere göre bir çokgen oluşturur ve bu çokgenin y eksenine göre çokgen setlerini sıralar.
    /// Çokgenlerin satır atladığını anlamak için en büyük y ekseninin bulunduğu çokgen belirlenir. 
    /// Bu bundan daha büyük bir çokgen var ise satır atlanır. Aksi halde yatayda devam etmektedir.
    /// </summary>
    public class ReceiptScannerService : IReceiptScannerService
    {
        public string ReceiptScan(List<Receipt> receipts)
        {
            int lineCount = 1;
            int maxYaxis = -1;

            IEnumerable<Receipt> sortedReceipts = receipts.Where(r => r.Locale == null)
                                                          .OrderBy(r => r.BoundingPoly.Vertices.Min(vertice => vertice.y));

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Receipt receipt in sortedReceipts)
            {
                if (receipt.BoundingPoly.Vertices.Any(x => x.y < maxYaxis))
                {
                    stringBuilder.Append(" ");
                    stringBuilder.Append(receipt.Description);             
                }
                else
                {
                    var receiptYaxis = receipt.BoundingPoly.Vertices.Max(vertice => vertice.y);


                    if (maxYaxis >= 0)
                    {
                        stringBuilder.Append('\n');
                    }

                    stringBuilder.Append($"{lineCount}-{receipt.Description}");
                    maxYaxis = receiptYaxis;
                    lineCount++;

                }

            }

            return stringBuilder.ToString();
        }
    }
}
