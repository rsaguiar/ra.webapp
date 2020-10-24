using RA.App.Domain;
using RA.App.Exception;
using Xunit;

namespace RA.App.Test
{
    public class PriceServiceEdit : PriceServiceTest
    {
        [Fact]
        public void CheckEdit()
        {
            // Arranje
            Price updatePrice = new Price
            {
                Id = 6,
                FromDDDCode = 18,
                ToDDDCode = 11,
                PricePerMinute = 3.9m
            };

            // Act
            _priceService.Edit(updatePrice);

            // Assert
            var expectedPrice = _priceService.Get(updatePrice.Id);
            Assert.NotNull(expectedPrice);
            Assert.Equal(expectedPrice.FromDDDCode, updatePrice.FromDDDCode);
            Assert.Equal(expectedPrice.ToDDDCode, updatePrice.ToDDDCode);
            Assert.Equal(expectedPrice.PricePerMinute, updatePrice.PricePerMinute);
        }

        [Fact]
        public void CheckEditWithExceptionReturn()
        {
            // Arranje
            Price updatePrice = new Price
            {
                Id = 6,
                FromDDDCode = 11,
                ToDDDCode = 16,
                PricePerMinute = 3.9m
            };

            // Act
            void act() => _priceService.Edit(updatePrice);

            // Assert
            string expectedMessage = "It is not possible to register a Price with the same source and destination.";
            PriceServiceException exception = Assert.Throws<PriceServiceException>(act);
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}