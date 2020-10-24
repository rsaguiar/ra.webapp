using RA.App.Domain;
using System.Collections.Generic;

namespace RA.App.Service.Interfaces {
    public interface ICalculatorService {
        IEnumerable<Calculator> GetAll();
        void Create(Calculator entity);
        Calculator CalculatePlanPrice(Calculator calculator, Price priceList);        
    }
}
