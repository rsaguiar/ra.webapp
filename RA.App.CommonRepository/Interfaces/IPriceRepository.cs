using RA.App.Domain;
using System.Collections.Generic;

namespace RA.App.CommonRepository.Interfaces {
    public interface IPriceRepository {
        Price Get(int id);
        Price Get(string title);
        IEnumerable<Price> GetAll();
        Price GetCalculatePrice(int sourceId, int destinationId);
        void Update(Price entity);
        void Remove(Price entity);
        void Add(Price entity);
    }
}
