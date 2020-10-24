using RA.App.CommonRepository.Interfaces;
using RA.App.Domain;
using RA.App.Exception;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RA.App.MockRepository {
    public class CalculatorMockRepository : MockRopository, ICalculatorRepository {
        private readonly List<Calculator> _data;

        public CalculatorMockRepository() {
            _data = _calculatorData.ToList();
        }

        public void Add(Calculator entity) {
            try {
                entity.Id = entity.Id > Decimal.Zero ? entity.Id : (_data.Count > 0 ?_data.Max(s => s.Id) + 1 : 1);
                _data.Add(entity);
            }
            catch (System.Exception ex) {
                throw new MockRepositoryException(ex);
            }
        }

        public IEnumerable<Calculator> GetAll() {
            try {
                return _data;
            }
            catch (System.Exception ex) {
                throw new MockRepositoryException(ex);
            }
        }
    }
}
