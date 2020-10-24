using RA.App.CommonRepository.Interfaces;
using RA.App.Domain;
using RA.App.Exception;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RA.App.MockRepository {
    public class PriceMockRepository : MockRopository, IPriceRepository {
        private readonly List<Price> _data;

        public PriceMockRepository() {
            _data = _priceData.ToList();
        }

        public void Add(Price entity) {
            try {
                entity.Id = entity.Id > Decimal.Zero ? entity.Id : (_data.Count > 0 ? _data.Max(s => s.Id) + 1 : 1);
                _data.Add(entity);
            }
            catch (System.Exception ex) {
                throw new MockRepositoryException(ex);
            }
        }

        public void Remove(Price entity) {
            try {
                _data.Remove(entity);
            }
            catch (System.Exception ex) {
                throw new MockRepositoryException(ex);
            }
        }

        public void Update(Price entity) {
            try {
                Remove(Get(entity.Id));
                Add(entity);
            }
            catch (System.Exception ex) {
                throw new MockRepositoryException(ex);
            }
        }

        public Price Get(int id) {
            try {
                return _data.FirstOrDefault(f => f.Id == id);
            }
            catch (System.Exception ex) {
                throw new MockRepositoryException(ex);
            }
        }

        public Price Get(string title) {
            try {
                return _data.FirstOrDefault();
            }
            catch (System.Exception ex) {
                throw new MockRepositoryException(ex);
            }
        }

        public IEnumerable<Price> GetAll() {
            try {
                return _data;
            }
            catch (System.Exception ex) {
                throw new MockRepositoryException(ex);
            }
        }

        public Price GetCalculatePrice(int sourceId, int destinationId) {
            try {
                return _data.Where(c => c.FromDDDCode == sourceId && c.ToDDDCode == destinationId).FirstOrDefault();
            }
            catch (System.Exception ex) {
                throw new MockRepositoryException(ex);
            }
        }
    }
}
