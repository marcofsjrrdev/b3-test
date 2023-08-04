namespace B3Test.Core.Interfaces
{
    public interface ICdbService
    {
        decimal CalculateCDB(decimal initialValue, int months);
        decimal CalculateTax(decimal redemptionValue, decimal initialValue, int months);
    }
}
