using B3Test.Core.Interfaces;
using B3Test.Core.Services;

namespace B3Test.Tests
{
    public class CDBServiceTests
    {
        private readonly CdbService cdbService;

        public CDBServiceTests()
        {
            cdbService = new CdbService();
        }

        [Theory]
        [InlineData(5000, 12, 5615.41)] // Valores esperados para o cálculo
        [InlineData(10000, 6, 10597.56)] // Outros exemplos de valores
        [InlineData(0, 0, 0)] // Valor inicial e meses igual a zero
        public void CalculateCDB_ShouldCalculateCorrectly(decimal initialValue, int months, decimal expectedValue)
        {
            // Act
            decimal result = cdbService.CalculateCDB(initialValue, months);

            // Assert
            Assert.Equal(expectedValue, result, 2); // Precisão de 2 casas decimais
        }

        [Theory]
        [InlineData(5000, 12, 123.08)] // Valor esperado para o imposto
        [InlineData(10000, 6, 134.45)] // Outros exemplos de valores
        [InlineData(0, 0, 0)] // Valor inicial e meses igual a zero
        public void CalculateTax_ShouldCalculateCorrectly(decimal initialValue, int months, decimal expectedTax)
        {
            //Arrange
            decimal getCalculateCDB = cdbService.CalculateCDB(initialValue, months);

            // Act
            decimal result = cdbService.CalculateTax(getCalculateCDB, initialValue, months);

            // Assert
            Assert.Equal(expectedTax, result, 2);
        }
    }
}