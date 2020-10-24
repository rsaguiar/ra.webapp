using RA.App.Domain;
using RA.App.Exception;
using Xunit;

namespace RA.App.Test {
    public class CalculatorServiceCalculatePlanPrice : CalculatorServiceTest {
       
        [Fact]
        public void CheckCalculatePlanPrice() {
            // Arranje
            Calculator expectedCalculatorPrice = new Calculator {
                Id = 1,
                FromDDDCode = 11,
                ToDDDCode = 16,
                Time = 20,
                PlanTypeId = 30,
                PriceWithPlan = 0m,
                PriceWithoutPlan = 38m
            };

            // Act
            var price = _priceService.GetCalculatePrice(expectedCalculatorPrice.FromDDDCode, expectedCalculatorPrice.ToDDDCode);
            var planPrice = _calculatorService.CalculatePlanPrice(expectedCalculatorPrice, price);
            
            // Assert
            Assert.NotNull(expectedCalculatorPrice);
            Assert.Equal(expectedCalculatorPrice.FromDDDCode, planPrice.FromDDDCode);
            Assert.Equal(expectedCalculatorPrice.ToDDDCode, planPrice.ToDDDCode);
            Assert.Equal(expectedCalculatorPrice.Time, planPrice.Time);
            Assert.Equal(expectedCalculatorPrice.PlanTypeId, planPrice.PlanTypeId);
            Assert.Equal(expectedCalculatorPrice.PriceWithPlan, planPrice.PriceWithPlan);
            Assert.Equal(expectedCalculatorPrice.PriceWithoutPlan, planPrice.PriceWithoutPlan);
        }

        [Fact]
        public void CheckCalculatePlanPriceWithoutExistingPrice() {
            // Arranje
            Calculator expectedCalculatorPrice = new Calculator {
                Id = 1,
                FromDDDCode = 18,
                ToDDDCode = 17,
                Time = 100,
                PlanTypeId = 30                
            };

            // Act
            var price = _priceService.GetCalculatePrice(expectedCalculatorPrice.FromDDDCode, expectedCalculatorPrice.ToDDDCode);
            var planPrice = _calculatorService.CalculatePlanPrice(expectedCalculatorPrice, price);

            // Assert
            Assert.NotNull(expectedCalculatorPrice);
            Assert.Equal(expectedCalculatorPrice.FromDDDCode, planPrice.FromDDDCode);
            Assert.Equal(expectedCalculatorPrice.ToDDDCode, planPrice.ToDDDCode);
            Assert.Equal(expectedCalculatorPrice.Time, planPrice.Time);
            Assert.Equal(expectedCalculatorPrice.PlanTypeId, planPrice.PlanTypeId);
            Assert.Equal(expectedCalculatorPrice.PriceWithPlan, planPrice.PriceWithPlan);
            Assert.Equal(expectedCalculatorPrice.PriceWithoutPlan, planPrice.PriceWithoutPlan);
        }
    }
}
