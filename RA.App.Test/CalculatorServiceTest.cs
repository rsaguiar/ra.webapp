using RA.App.CommonRepository.Interfaces;
using RA.App.Service;
using RA.App.Service.Interfaces;
using RA.App.MockRepository;

namespace RA.App.Test {
    public abstract class CalculatorServiceTest 
    {
        protected readonly IPriceService _priceService;
        protected readonly ICalculatorService _calculatorService;
        protected readonly ICalculatorRepository _mockCalculatorRepository;
        protected readonly IPriceRepository _mockPriceRepository;

        public CalculatorServiceTest() {
            _mockCalculatorRepository = new CalculatorMockRepository();
            _mockPriceRepository = new PriceMockRepository();
            _calculatorService = new CalculatorService(_mockCalculatorRepository);
            _priceService = new PriceService(_mockPriceRepository);
        }
    }
}
