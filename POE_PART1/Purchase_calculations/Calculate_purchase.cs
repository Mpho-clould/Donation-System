using Microsoft.EntityFrameworkCore;
using POE_PART1.Data;

namespace POE_PART1.Purchase_calculations
{
    public class Calculate_purchase
    {
        private readonly POE_PART1Context _context;
        public Calculate_purchase(POE_PART1Context context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalAmount()
        {
            var Total_Money_Donations = await _context.Monetary_donations.SumAsync(m => m.Amount);
            var Total_Purchases = await _context.Purchase.SumAsync(g => g.Price);

            var TotalAmount = Total_Money_Donations - Total_Purchases;
            return (decimal)TotalAmount;
        }

    }
}
