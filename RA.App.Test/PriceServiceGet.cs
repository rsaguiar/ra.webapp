using RA.App.Domain;
using Xunit;

namespace RA.App.Test
{
    public class PriceServiceGet : PriceServiceTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ReturnValue(int id)
        {
            // Arranje / Act
            var price = _priceService.Get(id);

            // Assert
            Assert.NotNull(price);
        }

        [Fact]
        public void ReturnCandLandValue()
        {
            // Arranje
            int id = 1;

            // Act
            var price = _priceService.Get(id);

            // Assert
            Price expectedPrice = new Price {
                FromDDDCode = 11,
                ToDDDCode = 16,
                PricePerMinute = 1.9m
            };

            Assert.NotNull(expectedPrice);
            Assert.Equal(expectedPrice.FromDDDCode, price.FromDDDCode);
            Assert.Equal(expectedPrice.ToDDDCode, price.ToDDDCode);
            Assert.Equal(expectedPrice.PricePerMinute, price.PricePerMinute);
        }

        [Fact]
        public void ReturnSorryValue()
        {
            // Arranje
            int id = 3;

            // Act
            var price = _priceService.Get(id);

            // Assert
            Price expectedPrice = new Price {
                FromDDDCode = 11,
                ToDDDCode = 17,
                PricePerMinute = 1.7m
            };

            Assert.NotNull(expectedPrice);
            Assert.Equal(expectedPrice.FromDDDCode, price.FromDDDCode);
            Assert.Equal(expectedPrice.ToDDDCode, price.ToDDDCode);
            Assert.Equal(expectedPrice.PricePerMinute, price.PricePerMinute);
        }
    }
}