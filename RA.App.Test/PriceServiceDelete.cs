using RA.App.Exception;
using Xunit;

namespace RA.App.Test
{
    public class PriceServiceDelete : PriceServiceTest
    {
        [Fact]
        public void CheckDelete()
        {
            // Arranje
            var price = _priceService.Get(1);

            // Act
            _priceService.Delete(price);

            // Assert
            string expectedMessage = "Price not available.";
            void actAssert() => _priceService.Get(price.Id);
            PriceServiceException exception = Assert.Throws<PriceServiceException>(actAssert);
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}