using RA.App.Domain;
using System.Collections.Generic;

namespace RA.App.CommonRepository.Interfaces {
    public interface ICalculatorRepository {
        IEnumerable<Calculator> GetAll();
        void Add(Calculator entity);
    }
}
