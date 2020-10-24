using RA.App.Domain;
using RA.App.Exception;
using System.Linq;
using Xunit;

namespace RA.App.Test {    
    public class CalculatorServiceCreate : CalculatorServiceTest {
        [Fact]
        public void CheckCreate() {
            // Arranje
            Calculator newCalculator = new Calculator {
                Id = 1,
                FromDDDCode = 11,
                ToDDDCode = 16,
                Time = 20,
                PlanTypeId = 30,
                PriceWithPlan = 0m,
                PriceWithoutPlan = 38m
            };

            // Act
            _calculatorService.Create(newCalculator);

            // Assert
            var expectedPrice = _mockCalculatorRepository.GetAll().Where(c => c.Id == 1).FirstOrDefault();
            Assert.NotNull(expectedPrice);
            Assert.Equal(expectedPrice.FromDDDCode, newCalculator.FromDDDCode);
            Assert.Equal(expectedPrice.ToDDDCode, newCalculator.ToDDDCode);
            Assert.Equal(expectedPrice.Time, newCalculator.Time);
            Assert.Equal(expectedPrice.PlanTypeId, newCalculator.PlanTypeId);
            Assert.Equal(expectedPrice.PriceWithPlan, newCalculator.PriceWithPlan);
            Assert.Equal(expectedPrice.PriceWithoutPlan, newCalculator.PriceWithoutPlan);
        }

        [Fact]
        public void CheckCreateWithExceptionReturn() {
            // Arranje
            Calculator newCalculator = new Calculator {
                Id = 1,
                FromDDDCode = 11,
                ToDDDCode = 16,
                Time = 0,
                PlanTypeId = 30,
                PriceWithPlan = 0m,
                PriceWithoutPlan = 0m
            };

            // Act
            void act() => _calculatorService.Create(newCalculator);

            // Assert
            string expectedMessage = "Calculator not available.";
            CalculatorServiceException exception = Assert.Throws<CalculatorServiceException>(act);
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
