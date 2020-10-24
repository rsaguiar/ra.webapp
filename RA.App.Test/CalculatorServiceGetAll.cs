using RA.App.Domain;
using System;
using System.Linq;
using Xunit;

namespace RA.App.Test {
    public class CalculatorServiceGetAll : CalculatorServiceTest {
        [Fact]
        public void ReturnAllEmpty() {
            // Arranje / Act
            var calcuatorList = _calculatorService.GetAll();

            // Assert
            Assert.NotNull(calcuatorList);
            Assert.True(calcuatorList.Count() == Decimal.Zero);
        }

        [Fact]
        public void ReturnAll() {
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
            _mockCalculatorRepository.Add(newCalculator);

            // Act
            var calcuatorList = _calculatorService.GetAll();

            // Assert
            Assert.NotNull(calcuatorList);
            Assert.True(calcuatorList.Count() > Decimal.Zero);
        }
    }
}
