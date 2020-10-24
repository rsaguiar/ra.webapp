using RA.App.Domain;
using RA.App.Exception;
using Xunit;

namespace RA.App.Test
{
    public class PriceServiceCreate : PriceServiceTest
    {
        [Fact]
        public void CheckCreate()
        {
            // Arranje
            Price newPrice = new Price
            {
                FromDDDCode = 11,
                ToDDDCode = 81,
                PricePerMinute = 2.49m
            };

            // Act
            _priceService.Create(newPrice);

            // Assert
            var expectedPrice = _mockRepository.GetCalculatePrice(newPrice.FromDDDCode, newPrice.ToDDDCode);
            Assert.NotNull(expectedPrice);
            Assert.Equal(expectedPrice.FromDDDCode, newPrice.FromDDDCode);
            Assert.Equal(expectedPrice.ToDDDCode, newPrice.ToDDDCode);
            Assert.Equal(expectedPrice.PricePerMinute, newPrice.PricePerMinute);
        }

        [Fact]
        public void CheckCreateWithExceptionReturn()
        {
            // Arranje
            Price newPrice = new Price
            {
                FromDDDCode = 11,
                ToDDDCode = 16,
                PricePerMinute = 2.49m
            };

            // Act
            void act() => _priceService.Create(newPrice);

            // Assert
            string expectedMessage = "It is not possible to register a Price with the same source and destination.";
            PriceServiceException exception = Assert.Throws<PriceServiceException>(act);
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
