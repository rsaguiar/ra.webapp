using RA.App.Domain;
using Xunit;

namespace RA.App.Test {
    public class PriceServiceGetCalculatePrice : PriceServiceTest {
        [Fact]
        public void ReturnAll() {
            // Arranje / Act
            var price = _priceService.GetCalculatePrice(11, 16);

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
    }
}
