using RA.App.CommonRepository.Interfaces;
using RA.App.Domain;
using RA.App.Exception;
using RA.App.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace RA.App.Service {
    public class PriceService : IPriceService {
        private readonly IPriceRepository _PriceRepository;

        public PriceService(IPriceRepository PriceRepository) {
            _PriceRepository = PriceRepository;
        }

        public IEnumerable<Price> GetAll() {
            return _PriceRepository.GetAll();
        }

        public Price GetCalculatePrice(int sourceId, int destinationId) {
            return _PriceRepository.GetCalculatePrice(sourceId, destinationId);
        }

        public void Delete(Price entity) {
            if (entity is null)
                throw new PriceServiceException("Price not available.");

            _PriceRepository.Remove(entity);
        }

        public void Edit(Price entity) {
            CreateOrEdit(entity, true);
        }

        public void Create(Price entity) {
            CreateOrEdit(entity, false);
        }

        public Price Get(int id) {
            if (id <= Decimal.Zero)
                throw new PriceServiceException("Invalid identifier.");

            var entity = _PriceRepository.Get(id);

            if (entity is null)
                throw new PriceServiceException("Price not available.");

            return entity;
        }

        private void CreateOrEdit(Price entity, bool isUpdate) {
            if (entity is null || !entity.IsValid())
                throw new PriceServiceException("Price not available.");

            var entityOld = _PriceRepository.GetCalculatePrice(entity.FromDDDCode, entity.ToDDDCode);

            if (!(entityOld is null) && entity.Id != entityOld.Id)
                throw new PriceServiceException("It is not possible to register a Price with the same source and destination.");

            if (isUpdate) {
                if (_PriceRepository.Get(entity.Id) is null)
                    throw new PriceServiceException("Register not found.");

                _PriceRepository.Update(entity);
            }
            else
                _PriceRepository.Add(entity);
        }
    }
}
