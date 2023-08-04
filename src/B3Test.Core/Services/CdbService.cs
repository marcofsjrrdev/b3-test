using B3Test.Core.Interfaces;

namespace B3Test.Core.Services
{
    public class CdbService : ICdbService
    {
        private const decimal taxBank = 1.08m; // Taxa banco sobre CDI 108%
        private const decimal taxCDI = 0.009m; // Taxa CDI 0.9%

        public decimal CalculateCDB(decimal initialValue, int months)
        {
            if (initialValue < 0 || months <= 0)
            {
                return 0;
            }

            decimal finalValue = initialValue;

            for (int i = 0; i < months; i++)
            {
                finalValue *= (1 + (taxCDI * taxBank));
            }

            decimal roundedFinalValue = Math.Round(finalValue, 2);
            return roundedFinalValue;
        }

        public decimal CalculateTax(decimal redemptionValue, decimal initialValue, int months)
        {
            if (redemptionValue <= 0 || months <= 0)
            {
                return 0;
            }

            decimal profit = CalculateCDB(initialValue, months) - initialValue;
            decimal taxValue = GetTaxValue(months);
            decimal tax = profit * taxValue;

            decimal roundedTax = Math.Round(tax, 2);
            return roundedTax;
        }

        private static decimal GetTaxValue(int months)
        {
            decimal taxValue = months switch
            {
                int n when n <= 6 => 0.225m,
                int n when n <= 12 => 0.20m,
                int n when n <= 24 => 0.175m,
                _ => 0.15m,
            };

            return taxValue;
        }
    }
}
