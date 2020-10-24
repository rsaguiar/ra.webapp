using RA.App.CommonRepository.Interfaces;
using RA.App.Service;
using RA.App.Service.Interfaces;
using RA.App.MockRepository;

namespace RA.App.Test
{
    public abstract class PriceServiceTest
    {
        protected readonly IPriceService _priceService;
        protected readonly IPriceRepository _mockRepository;

        public PriceServiceTest()
        {
            _mockRepository = new PriceMockRepository();
            _priceService = new PriceService(_mockRepository);
        }
    }
}
