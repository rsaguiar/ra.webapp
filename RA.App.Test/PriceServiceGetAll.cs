using System;
using System.Linq;
using Xunit;

namespace RA.App.Test
{
    public class PriceServiceGetAll : PriceServiceTest
    {
        [Fact]
        public void ReturnAll()
        {
            // Arranje / Act
            var priceList = _priceService.GetAll();

            // Assert
            Assert.NotNull(priceList);
            Assert.True(priceList.Count() > Decimal.Zero);
        }
    }
}
