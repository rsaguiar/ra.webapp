using RA.App.CommonRepository.Interfaces;
using RA.App.Domain;
using RA.App.Exception;
using RA.App.Service.Interfaces;
using System.Collections.Generic;

namespace RA.App.Service {
    public class CalculatorService : ICalculatorService {
        private readonly ICalculatorRepository _CalculatorRepository;

        public CalculatorService(ICalculatorRepository CalculatorRepository) {
            _CalculatorRepository = CalculatorRepository;
        }
        public IEnumerable<Calculator> GetAll() {
            return _CalculatorRepository.GetAll();
        }

        public void Create(Calculator entity) {
            if (entity is null || !entity.IsValid())
                throw new CalculatorServiceException("Calculator not available.");

            _CalculatorRepository.Add(entity);
        }

        public Calculator CalculatePlanPrice(Calculator calculator, Price price) {
            if (price != null) {
                if (calculator.Time < calculator.PlanTypeId) {
                    calculator.PriceWithPlan = 0;
                }
                else {
                    calculator.PriceWithPlan = (calculator.Time - calculator.PlanTypeId) * price.PricePerMinute * 1.1m;
                }

                calculator.PriceWithoutPlan = calculator.Time * price.PricePerMinute;
            }

            return calculator;
        }
    }
}
